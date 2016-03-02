using System.Windows.Forms;

namespace UsecaseHelper
{
    /// <summary>
    ///     Simple form showing a single text box.
    /// </summary>
    public partial class TextPrompt : Form
    {
        /// <summary>
        ///     The string in the text box.
        /// </summary>
        public string Input
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        /// <summary>
        ///     The label in the form.
        /// </summary>
        public string Label
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        public TextPrompt()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Confirms the dialog.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not
        ///     include event data.
        /// </param>
        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        ///     Cancels the dialog.
        /// </summary>
        /// <param name="sender">The object that triggered this listener.</param>
        /// <param name="e">
        ///     Represents the base class for classes that contain event data, and provides a value to use for events that do not
        ///     include event data.
        /// </param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
