using System;
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
    public partial class UseCaseForm : Form
    {
        public new string Name => txtName.Text;
        public string Summary => txtSummary.Text;
        public string Assumptions => txtAssumptions.Text;
        public string Description => txtDescription.Text;
        public string Exceptions => txtExceptions.Text;
        public string Result => txtResult.Text;

        public UseCaseForm()
        {
            InitializeComponent();
        }
    }
}
