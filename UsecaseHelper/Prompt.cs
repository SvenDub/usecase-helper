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
            TextPrompt prompt = new TextPrompt
            {
                Text = caption,
                Label = text
            };

            return prompt.ShowDialog() == DialogResult.OK ? prompt.Input : "";
        }
    }
}