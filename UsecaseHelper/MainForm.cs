using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            _drawables.ForEach(drawable =>
            {
                if (drawable == SelectedDrawable)
                {
                    SelectedDrawable.DrawGhost(e.Graphics);
                }
                else
                {
                    drawable.Draw(e.Graphics);
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
        }

        private void CreateObject(int x, int y)
        {
            if (rdiElementActor.Checked)
            {
                string name = Prompt.ShowDialog("Name:", "Create new actor");
                _drawables.Add(new Actor()
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

                _drawables.Add(new UseCase()
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

        private void imgDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedDrawable = _drawables.Find(drawable => drawable.InSelection(e.X, e.Y));
        }

        private void imgDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            SelectedDrawable?.Move(e.X, e.Y);
            SelectedDrawable = null;
        }

        private void imgDrawing_MouseLeave(object sender, System.EventArgs e)
        {
            SelectedDrawable = null;
        }

        private void imgDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedDrawable != null)
            {
                SelectedDrawable.GhostX = e.X;
                SelectedDrawable.GhostY = e.Y;
                imgDrawing.Invalidate();
            }
        }

        private void btnClearAll_Click(object sender, System.EventArgs e)
        {
            _drawables.Clear();

            imgDrawing.Invalidate();
        }
    }
}
