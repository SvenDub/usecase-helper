using System.Windows.Forms;

namespace UsecaseHelper
{
    public partial class TextPrompt : Form
    {
        public string Input
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public string Label
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        public TextPrompt()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
