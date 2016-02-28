using System.Windows.Forms;

namespace UsecaseHelper
{
    /// <summary>
    ///     Contains convenience methods for showing prompts.
    /// </summary>
    public static class Prompt
    {
        /// <summary>
        ///     Shows a dialog with a single input box.
        /// </summary>
        /// <param name="text">The text to display in the prompt.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <returns>The input or an empty string if the dialog is canceled.</returns>
        public static string ShowDialog(string text, string caption)
        {
            // Create form
            Form prompt = new Form
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Create elements
            Label textLabel = new Label {Left = 50, Top = 20, Text = text};
            TextBox textBox = new TextBox {Left = 50, Top = 50, Width = 400};
            Button confirmation = new Button
            {
                Text = "OK",
                Left = 350,
                Width = 100,
                Top = 80,
                DialogResult = DialogResult.OK
            };

            // Add elements
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}