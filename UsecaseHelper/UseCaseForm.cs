using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UsecaseHelper
{
    /// <summary>
    ///     Prompt for editing use cases.
    /// </summary>
    public partial class UseCaseForm : Form
    {
        public UseCaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     The name of the use case.
        /// </summary>
        public string CaseName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        /// <summary>
        ///     The summary of the use case.
        /// </summary>
        public string Summary
        {
            get { return txtSummary.Text; }
            set { txtSummary.Text = value; }
        }

        /// <summary>
        ///     The assumptions of the use case.
        /// </summary>
        public string Assumptions
        {
            get { return txtAssumptions.Text; }
            set { txtAssumptions.Text = value; }
        }

        /// <summary>
        ///     The description of the use case.
        /// </summary>
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        ///     The exceptions of this use case.
        /// </summary>
        public string Exceptions
        {
            get { return txtExceptions.Text; }
            set { txtExceptions.Text = value; }
        }

        /// <summary>
        ///     The result of this use case.
        /// </summary>
        public string Result
        {
            get { return txtResult.Text; }
            set { txtResult.Text = value; }
        }

        /// <summary>
        ///     The actors of this use case.
        /// </summary>
        public List<Actor> Actors
        {
            set { txtActors.Text = string.Join(", ", value); }
        }

        /// <summary>
        ///     Confirm edit.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not include event data.
        /// </param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}