using System.Text.RegularExpressions;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace JuiceTime
{
    class MessageDialogFactory
    {
        private TextBox _box;

        //If the creation of other dialogs using this method is desired, add a boolean (or multiple) argument to determine whether it is a specific dialog command
            // I.E.: "bool isFixInvalidTextBoxValue" which will help choose the correct code to run when a command is invoked.
        public MessageDialog CreateDialog(TextBox textBox)
        {
            _box = textBox;

            MessageDialog dialogOut = new MessageDialog("You may only use the following characters: ., 0, 1, 2, 3, 4, 5, 6, 7, 8, and 9", "Invalid Character!");

            dialogOut.Commands.Add(new UICommand(
                "Fix This For Me",
                Target
                ));
            dialogOut.Commands.Add(new UICommand("Just Delete The Value", Target));

            return dialogOut;
        }

        private void Target(IUICommand command)
        {
            if (command.Label.Contains("Fix"))
            {
                var validChars = ".0123456789".ToCharArray();
                //If the TextBox's Text value contains any valid characters, remove the invalid ones. Otherwise, set the value to "0"
                _box.Text = _box.Text.IndexOfAny(validChars) != -1 ? Regex.Replace(_box.Text, @"([^0-9]+)", "") : "0";
            }
            else
            {
                _box.Text = "0";
            }
        }

    }
}
