using System.Collections.Generic;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JuiceTime.Views
{
    public sealed partial class RecipePage
    {
        public RecipePage() => InitializeComponent();

        internal Recipe CreateRecipeFromData(string notes)
        {

            var thisRecipe = new Recipe(
                PGNic.QuickParse(),
                NicStr.QuickParse(),
                TargetStrength.QuickParse(),
                TargetVolume.QuickParse(),
                TargetPG.QuickParse(),
                GetFlavors(),
                notes,
                WaterPercentage.QuickParse()
            );
            return thisRecipe;
        }

        internal string CreateDataFromRecipe(Recipe recipe)
        {
            var (pgNic, nicStr, targetStr, targetVol, targetPg, flavors, notes, waterVodkaPga) = recipe;

            PGNic.Text = pgNic.ToString(CultureInfo.CurrentCulture);
            NicStr.Text = nicStr.ToString(CultureInfo.CurrentCulture);
            TargetStrength.Text = targetStr.ToString(CultureInfo.CurrentCulture);
            TargetVolume.Text = targetVol.ToString(CultureInfo.CurrentCulture);
            TargetPG.Text = targetPg.ToString(CultureInfo.CurrentCulture);
            WaterPercentage.Text = waterVodkaPga.ToString(CultureInfo.CurrentCulture);
            PushFlavorsToData(flavors);

            return notes;
        }

        private List<Flavor> GetFlavors()
        {
            var thisFlavors = new List<Flavor>();

            var flavor1 = new Flavor("Brand Placeholder", Flavor1Name.Text, Flavor1PG.QuickParse(), Flavor1Percentage.QuickParse());
            var flavor2 = new Flavor("Brand Placeholder", Flavor2Name.Text, Flavor2PG.QuickParse(), Flavor2Percentage.QuickParse());
            var flavor3 = new Flavor("Brand Placeholder", Flavor3Name.Text, Flavor3PG.QuickParse(), Flavor3Percentage.QuickParse());
            var flavor4 = new Flavor("Brand Placeholder", Flavor4Name.Text, Flavor4PG.QuickParse(), Flavor4Percentage.QuickParse());
            var flavor5 = new Flavor("Brand Placeholder", Flavor5Name.Text, Flavor5PG.QuickParse(), Flavor5Percentage.QuickParse());
            var flavor6 = new Flavor("Brand Placeholder", Flavor6Name.Text, Flavor6PG.QuickParse(), Flavor6Percentage.QuickParse());
            var flavor7 = new Flavor("Brand Placeholder", Flavor7Name.Text, Flavor7PG.QuickParse(), Flavor7Percentage.QuickParse());
            var flavor8 = new Flavor("Brand Placeholder", Flavor8Name.Text, Flavor8PG.QuickParse(), Flavor8Percentage.QuickParse());
            var flavor9 = new Flavor("Brand Placeholder", Flavor9Name.Text, Flavor9PG.QuickParse(), Flavor9Percentage.QuickParse());
            var flavor10 = new Flavor("Brand Placeholder", Flavor10Name.Text, Flavor10PG.QuickParse(), Flavor10Percentage.QuickParse());

            Flavor[] arrFlavors =
                {flavor1, flavor2, flavor3, flavor4, flavor5, flavor6, flavor7, flavor8, flavor9, flavor10};
            thisFlavors.AddRange(arrFlavors);
            return thisFlavors;
        }

        private void PushFlavorsToData(List<Flavor> flavors)
        {
            //TODO: set Flavor Brand Names once the control exists!!

            var flavor1 = flavors[0];
            var flavor2 = flavors[1];
            var flavor3 = flavors[2];
            var flavor4 = flavors[3];
            var flavor5 = flavors[4];
            var flavor6 = flavors[5];
            var flavor7 = flavors[6];
            var flavor8 = flavors[7];
            var flavor9 = flavors[8];
            var flavor10 = flavors[9];

            var (flavor1Brand, flavor1Name, flavor1Pg, flavor1Percentage) = flavor1;
            Flavor1Name.Text = flavor1Name;
            Flavor1PG.Text = flavor1Pg.ToString(CultureInfo.CurrentCulture);
            Flavor1Percentage.Text = flavor1Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor2Brand, flavor2Name, flavor2Pg, flavor2Percentage) = flavor2;
            Flavor2Name.Text = flavor2Name;
            Flavor2PG.Text = flavor2Pg.ToString(CultureInfo.CurrentCulture);
            Flavor2Percentage.Text = flavor2Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor3Brand, flavor3Name, flavor3Pg, flavor3Percentage) = flavor3;
            Flavor3Name.Text = flavor3Name;
            Flavor3PG.Text = flavor3Pg.ToString(CultureInfo.CurrentCulture);
            Flavor3Percentage.Text = flavor3Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor4Brand, flavor4Name, flavor4Pg, flavor4Percentage) = flavor4;
            Flavor4Name.Text = flavor4Name;
            Flavor4PG.Text = flavor4Pg.ToString(CultureInfo.CurrentCulture);
            Flavor4Percentage.Text = flavor4Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor5Brand, flavor5Name, flavor5Pg, flavor5Percentage) = flavor5;
            Flavor5Name.Text = flavor5Name;
            Flavor5PG.Text = flavor5Pg.ToString(CultureInfo.CurrentCulture);
            Flavor5Percentage.Text = flavor5Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor6Brand, flavor6Name, flavor6Pg, flavor6Percentage) = flavor6;
            Flavor6Name.Text = flavor6Name;
            Flavor6PG.Text = flavor6Pg.ToString(CultureInfo.CurrentCulture);
            Flavor6Percentage.Text = flavor6Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor7Brand, flavor7Name, flavor7Pg, flavor7Percentage) = flavor7;
            Flavor7Name.Text = flavor7Name;
            Flavor7PG.Text = flavor7Pg.ToString(CultureInfo.CurrentCulture);
            Flavor7Percentage.Text = flavor7Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor8Brand, flavor8Name, flavor8Pg, flavor8Percentage) = flavor8;
            Flavor8Name.Text = flavor8Name;
            Flavor8PG.Text = flavor8Pg.ToString(CultureInfo.CurrentCulture);
            Flavor8Percentage.Text = flavor8Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor9Brand, flavor9Name, flavor9Pg, flavor9Percentage) = flavor9;
            Flavor9Name.Text = flavor9Name;
            Flavor9PG.Text = flavor9Pg.ToString(CultureInfo.CurrentCulture);
            Flavor9Percentage.Text = flavor9Percentage.ToString(CultureInfo.CurrentCulture);

            var (flavor10Brand, flavor10Name, flavor10Pg, flavor10Percentage) = flavor10;
            Flavor10Name.Text = flavor10Name;
            Flavor10PG.Text = flavor10Pg.ToString(CultureInfo.CurrentCulture);
            Flavor10Percentage.Text = flavor10Percentage.ToString(CultureInfo.CurrentCulture);
        }

        private void PGNic_OnTextChanged(object sender, TextChangedEventArgs e) => PGNic.HandlePercentageHandlers(VGNic);

        private void VGNic_OnTextChanged(object sender, TextChangedEventArgs e) => VGNic.HandlePercentageHandlers(PGNic);

        private void Flavor1PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor1PG.HandlePercentageHandlers(Flavor1VG);

        private void Flavor1VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor1VG.HandlePercentageHandlers(Flavor1PG);

        private void Flavor2PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor2PG.HandlePercentageHandlers(Flavor2VG);

        private void Flavor2VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor2VG.HandlePercentageHandlers(Flavor2PG);

        private void Flavor3PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor3PG.HandlePercentageHandlers(Flavor3VG);

        private void Flavor3VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor3VG.HandlePercentageHandlers(Flavor3PG);

        private void Flavor4PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor4PG.HandlePercentageHandlers(Flavor4VG);

        private void Flavor4VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor4VG.HandlePercentageHandlers(Flavor4PG);

        private void Flavor5PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor5PG.HandlePercentageHandlers(Flavor5VG);
        
        private void Flavor5VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor5VG.HandlePercentageHandlers(Flavor5PG);

        private void Flavor6PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor6PG.HandlePercentageHandlers(Flavor6VG);

        private void Flavor6VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor6VG.HandlePercentageHandlers(Flavor6PG);

        private void Flavor7PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor7PG.HandlePercentageHandlers(Flavor7VG);

        private void Flavor7VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor7VG.HandlePercentageHandlers(Flavor7PG);

        private void Flavor8PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor8PG.HandlePercentageHandlers(Flavor8VG);

        private void Flavor8VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor8VG.HandlePercentageHandlers(Flavor8PG);

        private void Flavor9PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor9PG.HandlePercentageHandlers(Flavor9VG);

        private void Flavor9VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor9VG.HandlePercentageHandlers(Flavor9PG);

        private void Flavor10PG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor10PG.HandlePercentageHandlers(Flavor10VG);

        private void Flavor10VG_OnTextChanged(object sender, TextChangedEventArgs e) => Flavor10VG.HandlePercentageHandlers(Flavor10PG);

        private void NicStr_OnLostFocus(object sender, RoutedEventArgs e) => NicStr.HandleValidatingBoxes();

        private void TargetPG_OnTextChanged(object sender, TextChangedEventArgs e) => TargetPG.HandlePercentageHandlers(TargetVG);

        private void TargetVG_OnTextChanged(object sender, TextChangedEventArgs e) => TargetVG.HandlePercentageHandlers(TargetPG);

    }
}
