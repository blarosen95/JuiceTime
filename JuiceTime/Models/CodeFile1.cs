using System;
using Windows.UI.Xaml;

namespace JuiceTime.Models
{
    public class ThemeChangedArgs : EventArgs
    {
        //Gets the Current UI Theme
        public ElementTheme Theme { get; internal set; }

        //Gets a value indicating whether the Theme was set by the User
        public bool CustomSet { get; internal set; }
    }

}