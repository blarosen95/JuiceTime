using System;
using System.Globalization;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace JuiceTime
{
    internal static class Extensions
    {
        public static string AsOppositePercentage(this TextBox textBox)
        {
            var text = textBox.Text;

            return double.TryParse(text, out var value) ? (100.0 - value).ToString(CultureInfo.CurrentCulture) : null;
        }

        public static async void HandlePercentageHandlers(this TextBox textBox, TextBox boxToUpdate)
        {
            const string validChars = ".0123456789";
            var messageDialogFactory = new MessageDialogFactory();

            if (!textBox.Text.All(validChars.Contains))
            {
                await messageDialogFactory.CreateDialog(textBox).ShowAsync();
            }

            if (textBox.Text.Equals(""))
                textBox.Text = "0";

            boxToUpdate.Text = textBox.AsOppositePercentage();
        }

        //Called by EventHandlers in order to prevent invalid characters from being used in certain textboxes
        public static async void HandleValidatingBoxes(this TextBox textBox)
        {
            const string validChars = ".0123456789";
            var messageDialogFactory = new MessageDialogFactory();

            if (!textBox.Text.All(validChars.Contains))
            {
                await messageDialogFactory.CreateDialog(textBox).ShowAsync();
            }
        }

        public static double QuickParse(this TextBox textBox)
        {
            double.TryParse(textBox.Text, out var result);
            return result;
        }

        public static double QuickParse(this TextBlock textBlock)
        {
            double.TryParse(textBlock.Text, out var result);
            return result;
        }

        public static double ToMl(this double percentage, double targetVol)
        {
            return (percentage * targetVol) / 100;
        }

    }
}
