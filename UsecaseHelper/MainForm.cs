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
    public partial class MainForm : Form
    {
        public const bool DrawBoundingBox = false;

        private readonly List<Drawable> _drawables = new List<Drawable>(); 

        private Actor _selectedActor;
        public static Drawable SelectedDrawable;

        public MainForm()
        {
            InitializeComponent();
        }

        private void imgDrawing_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

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

        private void CreateObject(int x, int y)
        {
            if (rdiElementActor.Checked)
            {
                string name = Prompt.ShowDialog("Name:", "Create new actor");
                _drawables.Add(new Actor
                {
                    Name = name,
                    X = x,
                    Y = y
                });
            }
            else if (rdiElementUseCase.Checked)
            {
                UseCaseForm useCaseForm = new UseCaseForm();

                useCaseForm.ShowDialog();

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
            else if (rdiElementLine.Checked)
            {
                if (_selectedActor == null)
                {
                    Actor selection = _drawables.FindAll(drawable => drawable is Actor).Find(actor => actor.InSelection(x, y)) as Actor;
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
                    UseCase selection = _drawables.FindAll(drawable => drawable is UseCase).Find(useCase => useCase.InSelection(x, y)) as UseCase;
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

        private void EditObject(int x, int y)
        {
            Drawable selection = _drawables.Find(drawable => drawable.InSelection(x, y));
            selection?.Edit();

            imgDrawing.Invalidate();
        }

        private void DeleteObject(int x, int y)
        {
            List<Drawable> deleteList = _drawables.FindAll(drawable => drawable.InSelection(x, y));

            _drawables.FindAll(drawable => drawable is UseCase).Cast<UseCase>().ToList().ForEach(useCase => useCase.Actors.RemoveAll(actor => deleteList.Contains(actor)));

            _drawables.RemoveAll(drawable => deleteList.Contains(drawable));

            imgDrawing.Invalidate();
        }

        private void UnlinkObject(int x, int y)
        {
            if (_selectedActor == null)
            {
                Actor selection = _drawables.FindAll(drawable => drawable is Actor).Find(actor => actor.InSelection(x, y)) as Actor;
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
                UseCase selection = _drawables.FindAll(drawable => drawable is UseCase).Find(useCase => useCase.InSelection(x, y)) as UseCase;
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

        private void imgDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedDrawable = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y));
        }

        private void imgDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            SelectedDrawable?.Move(e.X, e.Y);
            SelectedDrawable = null;
        }

        private void imgDrawing_MouseLeave(object sender, EventArgs e)
        {
            SelectedDrawable = null;

            statusBarLabel.Text = "Ready";
        }

        private void imgDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedDrawable != null)
            {
                SelectedDrawable.GhostX = e.X;
                SelectedDrawable.GhostY = e.Y;
                imgDrawing.Invalidate();
            }

            if (rdiModeCreate.Checked)
            {
                if (rdiElementActor.Checked)
                {
                    statusBarLabel.Text = "Create a new actor";
                }
                else if (rdiElementUseCase.Checked)
                {
                    statusBarLabel.Text = "Create a new use case";
                }
                else if (rdiElementLine.Checked)
                {
                    if (_selectedActor == null)
                    {
                        Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is Actor);
                        statusBarLabel.Text = selection == null ? "Select an actor" : $"Link {selection.Name}";
                    }
                    else
                    {
                        Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is UseCase);
                        statusBarLabel.Text = selection == null ? "Select a use case" : $"Link {_selectedActor.Name} to {selection.Name}";
                    }
                }
            }
            else if (rdiModeDelete.Checked)
            {
                Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y));

                statusBarLabel.Text = selection != null ? $"Delete {selection.Name}" : "Ready";
            }
            else if (rdiModeUnlink.Checked)
            {
                if (_selectedActor == null)
                {
                    Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is Actor);
                    statusBarLabel.Text = selection == null ? "Select an actor" : $"Unlink {selection.Name}";
                }
                else
                {
                    Drawable selection = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y) && drawable is UseCase);
                    statusBarLabel.Text = selection == null ? "Select a use case" : $"Unlink {_selectedActor.Name} from {selection.Name}";
                }
            } 
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

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            _drawables.Clear();

            imgDrawing.Invalidate();
        }

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

                Bitmap bitmap = new Bitmap(imgDrawing.Width, imgDrawing.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bitmap);

                g.Clear(Color.White);

                Draw(g);

                bitmap.Save(filename, imageFormat);

                statusBarLabel.Text = "Ready";
            }
        }

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

                string json = JsonConvert.SerializeObject(_drawables, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto
                });

                File.WriteAllText(filename, json);

                statusBarLabel.Text = "Ready";
            }

        }

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

                string json = File.ReadAllText(dialog.FileName);

                try
                {
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
