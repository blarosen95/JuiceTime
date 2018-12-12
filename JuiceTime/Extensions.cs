﻿using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace JuiceTime
{
    internal static class Extensions
    {
        public static string AsOppositePercentage(this TextBox textBox)
        {
            var text = textBox.Text;

            return double.TryParse(text, out var value) ? (100.0 - value).ToString() : null;
        }

        public static async void HandlePercentageHandlers(this TextBox textBox, TextBox boxToUpdate)
        {
            string validChars = ".0123456789";
            MessageDialogFactory messageDialogFactory = new MessageDialogFactory();

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
            string validChars = ".0123456789";
            MessageDialogFactory messageDialogFactory = new MessageDialogFactory();

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

    }
}