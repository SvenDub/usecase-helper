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
        private List<UseCase> _useCases = new List<UseCase>();
        private List<Actor> _actors = new List<Actor>(); 

        public MainForm()
        {
            InitializeComponent();
        }

        private void imgDrawing_Paint(object sender, PaintEventArgs e)
        {
            
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
                    Name = useCaseForm.Name,
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
                
            }
        }
    }
}
