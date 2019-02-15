using System;
using System.IO;
using Windows.Globalization.DateTimeFormatting;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JuiceTime.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GramsPage
    {
        private ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        public GramsPage()
        {
            InitializeComponent();
            PreparePage();
        }

        async void WriteJson(string jsonData)
        {
            var formatter = new DateTimeFormatter("longtime");

            var gramsSetFile =
                await _localFolder.CreateFileAsync("GramsSet.JSON", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(gramsSetFile, jsonData);

        }

        private void GramsSetButton_OnClick(object sender, RoutedEventArgs e)
        {
            var grams = new Grams(NicGrams.QuickParse(), PGGrams.QuickParse(), VGGrams.QuickParse(), WaterGrams.QuickParse(), FlavoringGrams.QuickParse());

            WriteJson(JsonConvert.SerializeObject(grams));

            //Close the popup
            if (Parent is Popup p)
            {
                p.IsOpen = false;
            }
        }

        private async void PreparePage()
        {
            try
            {
                StorageFile gramsFile = await _localFolder.GetFileAsync("GramsSet.JSON");

                Grams grams = JsonConvert.DeserializeObject<Grams>(await FileIO.ReadTextAsync(gramsFile));
                //TODO find out if C#7 allows for an overload constructor with the same number, but different type, of params.
                // Changed the final variable in the following Deconstruction to a disposable ("_"), instead of declaring a variable, "filler", here and using it in the deconstruction. 
                (NicGrams.Text, PGGrams.Text, VGGrams.Text, WaterGrams.Text, FlavoringGrams.Text, _) = grams;

            }
            catch (FileNotFoundException)
            {
                //If this is caught, then the grams have not been set before
                var messageDialog = new MessageDialog("Please enter the density (grams per ml) of your ingredients.",
                    "First Time Setting Grams?");
                await messageDialog.ShowAsync();
            }
        }

    }
}
