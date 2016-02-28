using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UsecaseHelper
{
    public partial class UseCaseForm : Form
    {
        public string CaseName
        {
            get { return txtName.Text; }
            set {  txtName.Text = value; }
        }

        public string Summary
        {
            get { return txtSummary.Text; }
            set { txtSummary.Text = value; }
        }

        public string Assumptions
        {
            get { return txtAssumptions.Text; }
            set { txtAssumptions.Text = value; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public string Exceptions
        {
            get { return txtExceptions.Text; }
            set { txtExceptions.Text = value; }
        }

        public string Result
        {
            get { return txtResult.Text; }
            set { txtResult.Text = value; }
        }

        public List<Actor> Actors
        {
            set { txtActors.Text = string.Join(", ", value); }
        }

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
