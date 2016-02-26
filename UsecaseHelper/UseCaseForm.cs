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
        public string CaseName => txtName.Text;
        public string Summary => txtSummary.Text;
        public string Assumptions => txtAssumptions.Text;
        public string Description => txtDescription.Text;
        public string Exceptions => txtExceptions.Text;
        public string Result => txtResult.Text;

        public UseCaseForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
