using System;
using System.IO;
using Windows.Globalization.DateTimeFormatting;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Newtonsoft.Json;

namespace JuiceTime.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GramsPage
    {
        private readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        private Grams _grams;

        public GramsPage()
        {
            InitializeComponent();
            PreparePage();
        }

        private async void WriteJson(string jsonData)
        {
            // TODO: Delete the following usage of DateTimeFormatter (seems unused and unnecessary for this class's goals)
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
                var gramsFile = await _localFolder.GetFileAsync("GramsSet.JSON");

                _grams = JsonConvert.DeserializeObject<Grams>(await FileIO.ReadTextAsync(gramsFile));
                //TODO find out if C#7 allows for an overload constructor with the same number, but different type, of params.
                // Changed the final variable in the following Deconstruction to a disposable ("_"), instead of declaring a variable, "filler", here and using it in the deconstruction. 
                (NicGrams.Text, PGGrams.Text, VGGrams.Text, WaterGrams.Text, FlavoringGrams.Text, _) = _grams;

            }
            catch (FileNotFoundException)
            {
                //If this is caught, then the grams have not been set before
                var messageDialog = new MessageDialog("Please enter the density (grams per ml) of your ingredients.",
                    "First Time Setting Grams?");
                await messageDialog.ShowAsync();
            }
        }

        public Grams GetGramsSetting()
        {
            return _grams;
        }

    }
}
