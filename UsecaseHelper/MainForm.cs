using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace UsecaseHelper
{
    /// <summary>
    ///     The main form showing all content.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Debug option for drawing bounding boxes.
        /// </summary>
        public const bool DrawBoundingBox = false;

        /// <summary>
        ///     The drawable that is currently selected.
        /// </summary>
        public static Drawable SelectedDrawable;

        /// <summary>
        ///     List of all drawables currently on the canvas.
        /// </summary>
        private readonly List<Drawable> _drawables = new List<Drawable>();

        /// <summary>
        ///     The actor that is selected for linking purposes.
        /// </summary>
        private Actor _selectedActor;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Repaints the canvas.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">Provides data for the <see cref="Control.Paint" /> event.</param>
        private void imgDrawing_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        /// <summary>
        ///     Draws all drawables to the given drawing surface.
        /// </summary>
        /// <param name="g">The drawing surface to draw to.</param>
        private void Draw(Graphics g)
        {
            _drawables.ForEach(drawable =>
            {
                if (drawable == SelectedDrawable)
                {
                    SelectedDrawable.DrawGhost(g);
                }
                else
                {
                    drawable.Draw(g);
                }
            });
        }

        /// <summary>
        ///     Handles clicks on the canvas.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Provides data for the <see cref="Control.MouseUp" />, <see cref="Control.MouseDown" />, and
        ///     <see cref="Control.MouseMove" /> events.
        /// </param>
        private void imgDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            if (rdiModeCreate.Checked)
            {
                CreateObject(e.X, e.Y);
            }
            else if (rdiModeSelect.Checked)
            {
                EditObject(e.X, e.Y);
            }
            else if (rdiModeDelete.Checked)
            {
                DeleteObject(e.X, e.Y);
            }
            else if (rdiModeUnlink.Checked)
            {
                UnlinkObject(e.X, e.Y);
            }
        }

        /// <summary>
        ///     Creates a new object at the given coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private void CreateObject(int x, int y)
        {
            // Create actor
            if (rdiElementActor.Checked)
            {
                string name = Prompt.ShowDialog("Name:", "Create new actor");

                if (!name.Equals(string.Empty))
                {
                    _drawables.Add(new Actor
                    {
                        Name = name,
                        X = x,
                        Y = y
                    });
                }
            }
            // Create use case
            else if (rdiElementUseCase.Checked)
            {
                UseCaseForm useCaseForm = new UseCaseForm();

                if (useCaseForm.ShowDialog() == DialogResult.OK)
                {
                    _drawables.Add(new UseCase
                    {
                        Name = useCaseForm.CaseName,
                        X = x,
                        Y = y,
                        Assumptions = useCaseForm.Assumptions,
                        Description = useCaseForm.Description,
                        Exceptions = useCaseForm.Exceptions,
                        Result = useCaseForm.Result,
                        Summary = useCaseForm.Summary
                    });
                }
            }
            // Create link
            else if (rdiElementLine.Checked)
            {
                if (_selectedActor == null)
                {
                    Actor selection =
                        _drawables.FindAll(drawable => drawable is Actor).Find(actor => actor.InSelection(x, y)) as
                            Actor;
                    if (selection == null)
                    {
                        MessageBox.Show("Select an actor");
                    }
                    else
                    {
                        _selectedActor = selection;
                    }
                }
                else
                {
                    UseCase selection =
                        _drawables.FindAll(drawable => drawable is UseCase).Find(useCase => useCase.InSelection(x, y))
                            as UseCase;
                    if (selection == null)
                    {
                        MessageBox.Show("Select a use case");
                    }
                    else
                    {
                        selection.Actors.Add(_selectedActor);
                        _selectedActor = null;
                    }
                }
            }

            imgDrawing.Invalidate();
        }

        /// <summary>
        ///     Edit the object at the given coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private void EditObject(int x, int y)
        {
            Drawable selection = _drawables.Find(drawable => drawable.InSelection(x, y));
            selection?.Edit();

            imgDrawing.Invalidate();
        }

        /// <summary>
        ///     Delete the object at the given coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private void DeleteObject(int x, int y)
        {
            List<Drawable> deleteList = _drawables.FindAll(drawable => drawable.InSelection(x, y));

            _drawables.FindAll(drawable => drawable is UseCase)
                .Cast<UseCase>()
                .ToList()
                .ForEach(useCase => useCase.Actors.RemoveAll(actor => deleteList.Contains(actor)));

            _drawables.RemoveAll(drawable => deleteList.Contains(drawable));

            imgDrawing.Invalidate();
        }

        /// <summary>
        ///     Unlink an actor and a use case.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private void UnlinkObject(int x, int y)
        {
            if (_selectedActor == null)
            {
                Actor selection =
                    _drawables.FindAll(drawable => drawable is Actor).Find(actor => actor.InSelection(x, y)) as Actor;
                if (selection == null)
                {
                    MessageBox.Show("Select an actor");
                }
                else
                {
                    _selectedActor = selection;
                }
            }
            else
            {
                UseCase selection =
                    _drawables.FindAll(drawable => drawable is UseCase).Find(useCase => useCase.InSelection(x, y)) as
                        UseCase;
                if (selection == null)
                {
                    MessageBox.Show("Select a use case");
                }
                else
                {
                    selection.Actors.Remove(_selectedActor);
                    _selectedActor = null;
                }
            }

            imgDrawing.Invalidate();
        }

        /// <summary>
        ///     Selects an object for dragging.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Provides data for the <see cref="Control.MouseUp" />, <see cref="Control.MouseDown" />, and
        ///     <see cref="Control.MouseMove" /> events.
        /// </param>
        private void imgDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedDrawable = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y));
        }

        /// <summary>
        ///     Moves and deselects a dragged object.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Provides data for the <see cref="Control.MouseUp" />, <see cref="Control.MouseDown" />, and
        ///     <see cref="Control.MouseMove" /> events.
        /// </param>
        private void imgDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            SelectedDrawable?.Move(e.X, e.Y);
            SelectedDrawable = null;
        }

        /// <summary>
        ///     Deselects a dragged object.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not
        ///     include event data.
        /// </param>
        private void imgDrawing_MouseLeave(object sender, EventArgs e)
        {
            SelectedDrawable = null;

            statusBarLabel.Text = "Ready";
        }

        /// <summary>
        ///     Show context information for the current cursor position.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Provides data for the <see cref="Control.MouseUp" />, <see cref="Control.MouseDown" />, and
        ///     <see cref="Control.MouseMove" /> events.
        /// </param>
        private void imgDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            // Draw ghost
            if (SelectedDrawable != null)
            {
                SelectedDrawable.GhostX = e.X;
                SelectedDrawable.GhostY = e.Y;
                imgDrawing.Invalidate();
            }

            // Create hint
            if (rdiModeCreate.Checked)
            {
                // Actor
                if (rdiElementActor.Checked)
                {
                    statusBarLabel.Text = "Create a new actor";
                }
                // Use case
                else if (rdiElementUseCase.Checked)
                {
                    statusBarLabel.Text = "Create a new use case";
                }
                // Link
                else if (rdiElementLine.Checked)
                {
                    if (_selectedActor == null)
                    {
                        Drawable selection =
                            _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is Actor);
                        statusBarLabel.Text = selection == null ? "Select an actor" : $"Link {selection.Name}";
                    }
                    else
                    {
                        Drawable selection =
                            _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is UseCase);
                        statusBarLabel.Text = selection == null
                            ? "Select a use case"
                            : $"Link {_selectedActor.Name} to {selection.Name}";
                    }
                }
            }
            // Delete hint
            else if (rdiModeDelete.Checked)
            {
                Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y));

                statusBarLabel.Text = selection != null ? $"Delete {selection.Name}" : "Ready";
            }
            // Unlink hint
            else if (rdiModeUnlink.Checked)
            {
                if (_selectedActor == null)
                {
                    Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is Actor);
                    statusBarLabel.Text = selection == null ? "Select an actor" : $"Unlink {selection.Name}";
                }
                else
                {
                    Drawable selection =
                        _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is UseCase);
                    statusBarLabel.Text = selection == null
                        ? "Select a use case"
                        : $"Unlink {_selectedActor.Name} from {selection.Name}";
                }
            }
            // Select/move hint
            else if (rdiModeSelect.Checked)
            {
                if (SelectedDrawable != null)
                {
                    statusBarLabel.Text = $"Moving {SelectedDrawable.Name}";
                }
                else
                {
                    Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y));
                    statusBarLabel.Text = selection == null
                        ? "Ready"
                        : $"Click to select {selection.Name} - Drag to move";
                }
            }
        }

        /// <summary>
        ///     Clears all drawables.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not
        ///     include event data.
        /// </param>
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            _drawables.Clear();

            imgDrawing.Invalidate();
        }

        /// <summary>
        ///     Exports current state as an image.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not
        ///     include event data.
        /// </param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "png",
                Filter = "Portable Network Graphics|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp",
                FileName = "Use Case"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filename = dialog.FileName;
                ImageFormat imageFormat;

                statusBarLabel.Text = $"Exporting to {filename}...";

                // Determine image format, depending on extension
                switch (dialog.FileName.Split('.').Last())
                {
                    default:
                    case "png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case "jpg":
                    case "jpeg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case "bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                }

                // Create bitmap
                Bitmap bitmap = new Bitmap(imgDrawing.Width, imgDrawing.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bitmap);

                g.Clear(Color.White);

                // Draw to bitmap
                Draw(g);

                // Save to file
                bitmap.Save(filename, imageFormat);

                statusBarLabel.Text = "Ready";
            }
        }

        /// <summary>
        ///     Exports current state as a text file.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not
        ///     include event data.
        /// </param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "json",
                Filter = "Json File|*.json",
                FileName = "Use Case"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filename = dialog.FileName;

                statusBarLabel.Text = $"Saving to {filename}...";

                // Serialize to json
                string json = JsonConvert.SerializeObject(_drawables, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto
                });

                // Save to file
                File.WriteAllText(filename, json);

                statusBarLabel.Text = "Ready";
            }
        }

        /// <summary>
        ///     Load state from a text file.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not
        ///     include event data.
        /// </param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Json File|*.json"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                statusBarLabel.Text = $"Loading from {dialog.FileName}...";

                // Read from file
                string json = File.ReadAllText(dialog.FileName);

                try
                {
                    // Deserialize from json
                    List<Drawable> drawables = JsonConvert.DeserializeObject<List<Drawable>>(json,
                        new JsonSerializerSettings
                        {
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                            TypeNameHandling = TypeNameHandling.Auto
                        });

                    _drawables.Clear();
                    _drawables.AddRange(drawables);

                    statusBarLabel.Text = "Ready";

                    imgDrawing.Invalidate();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.StackTrace);

                    statusBarLabel.Text = $"Failed ({exception.Message})";
                }
            }
        }
    }
}