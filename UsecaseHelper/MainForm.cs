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
        public const bool DrawBoundingBox = true;

        private readonly List<UseCase> _useCases = new List<UseCase>();
        private readonly List<Actor> _actors = new List<Actor>();

        private Actor _selectedActor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void imgDrawing_Paint(object sender, PaintEventArgs e)
        {
            for (int x = 0; x < imgDrawing.Width; x++)
            {
                for (int y = 0; y < imgDrawing.Height; y++)
                {
                    if (_actors.Find(actor => actor.InSelection(x, y)) != null)
                    {
                        e.Graphics.DrawEllipse(Pens.Green, x, y, 1, 1);
                    }

                    if (_useCases.Find(useCase => useCase.InSelection(x, y)) != null)
                    {
                        e.Graphics.DrawEllipse(Pens.Blue, x, y, 1, 1);
                    }
                }
            }
            _useCases.ForEach(useCase => useCase.Draw(e.Graphics));
            _actors.ForEach(actor => actor.Draw(e.Graphics));
        }

        private void imgDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            if (rdiModeCreate.Checked)
            {
                CreateObject(e.X, e.Y);
            }
            else if (rdiModeSelect.Checked)
            {
                
            }
        }

        private void CreateObject(int x, int y)
        {
            if (rdiElementActor.Checked)
            {
                string name = Prompt.ShowDialog("Name:", "Create new actor");
                _actors.Add(new Actor()
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

                _useCases.Add(new UseCase()
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
                    Actor selection = _actors.Find(actor => actor.InSelection(x, y));
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
                    UseCase selection = _useCases.Find(useCase => useCase.InSelection(x, y));
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
    }
}
