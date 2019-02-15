using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JuiceTime.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {

        public SettingsPage()
        {
            this.InitializeComponent();
            var Listener = new ThemeListener();
            this.Loaded += SettingsPage_Loaded;
            Listener.ThemeChanged += Listener_ThemeChanged;
            //App.Current.ThemeChanged += Current_ThemeChanged;
        }

        private void Current_ThemeChanged(object sender, Models.ThemeChangedArgs e)
        {
            UpdateThemeState();
        }

        private void UpdateThemeState()
        {
            //SystemTheme.Text
        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateThemeState();
        }

        private void Listener_ThemeChanged(ThemeListener sender)
        {
            UpdateThemeState();
        }

        private void ToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
