using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JuiceTime.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalculatePage
    {
        //TODO: replace the use of a field containing this app's instance of the RecipePage with a more conventional/functional approach
        private readonly Recipe _recipe;

        private readonly GramsPage _gramsPage = new GramsPage();
        private static double _vgGrams, _pgGrams, _nicGrams, _waterGrams, _flavoringGrams;


        public CalculatePage(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe;

            var grams = _gramsPage.GetGramsSetting();
            (_nicGrams, _pgGrams, _vgGrams, _waterGrams, _flavoringGrams) = grams;
        }

        //Called every time the user loads the CalculatePage as the view
        public void CalculateValues()
        {
            //TODO: Perform calculations using RecipePage's data
            //Do here
            var (pgNic, nicStr, targetStr, targetVol, targetPg, flavors, notes, waterVodkaPga) = _recipe;
            var (brand1, name1, pgToVG1, percent1) = flavors[0];
            var (brand2, name2, pgToVG2, percent2) = flavors[1];
            var (brand3, name3, pgToVG3, percent3) = flavors[2];
            var (brand4, name4, pgToVG4, percent4) = flavors[3];
            var (brand5, name5, pgToVG5, percent5) = flavors[4];
            var (brand6, name6, pgToVG6, percent6) = flavors[5];
            var (brand7, name7, pgToVG7, percent7) = flavors[6];
            var (brand8, name8, pgToVG8, percent8) = flavors[7];
            var (brand9, name9, pgToVG9, percent9) = flavors[8];
            var (brand10, name10, pgToVG10, percent10) = flavors[9];

            //TODO: Update this page's controls to reflect the current calculations for each value
            NicotineMl.Text = (targetStr * targetVol / nicStr).ToString(CultureInfo.CurrentCulture);

            NicotinePercent.Text = (NicotineMl.QuickParse() / targetVol * 100).ToString(CultureInfo.CurrentCulture);
            PGPercent.Text = GetDifferencePGTotal(flavors, targetPg, pgNic, NicotinePercent.QuickParse())
                .ToString(CultureInfo.CurrentCulture);
            VGPercent.Text = GetDifferenceVGTotal(flavors, 100 - targetPg, 100 - pgNic, NicotinePercent.QuickParse())
                .ToString(CultureInfo.CurrentCulture);
            WaterPercent.Text = waterVodkaPga.ToString(CultureInfo.CurrentCulture);
            Flavor1Percent.Text = percent1.ToString(CultureInfo.CurrentCulture);
            Flavor2Percent.Text = percent2.ToString(CultureInfo.CurrentCulture);
            Flavor3Percent.Text = percent3.ToString(CultureInfo.CurrentCulture);
            Flavor4Percent.Text = percent4.ToString(CultureInfo.CurrentCulture);
            Flavor5Percent.Text = percent5.ToString(CultureInfo.CurrentCulture);
            Flavor6Percent.Text = percent6.ToString(CultureInfo.CurrentCulture);
            Flavor7Percent.Text = percent7.ToString(CultureInfo.CurrentCulture);
            Flavor8Percent.Text = percent8.ToString(CultureInfo.CurrentCulture);
            Flavor9Percent.Text = percent9.ToString(CultureInfo.CurrentCulture);
            Flavor10Percent.Text = percent10.ToString(CultureInfo.CurrentCulture);
            TotalPercent.Text = GetSumByColumn(CalcGrid, List.Of(0, 1, 16), 3).ToString(CultureInfo.CurrentCulture);

            Flavor1Name.Text = name1;
            Flavor2Name.Text = name2;
            Flavor3Name.Text = name3;
            Flavor4Name.Text = name4;
            Flavor5Name.Text = name5;
            Flavor6Name.Text = name6;
            Flavor7Name.Text = name7;
            Flavor8Name.Text = name8;
            Flavor9Name.Text = name9;
            Flavor10Name.Text = name10;

            PGMl.Text = PGPercent.QuickParse().ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            VGMl.Text = VGPercent.QuickParse().ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor1Ml.Text = percent1.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor2Ml.Text = percent2.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor3Ml.Text = percent3.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor4Ml.Text = percent4.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor5Ml.Text = percent5.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor6Ml.Text = percent6.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor7Ml.Text = percent7.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor8Ml.Text = percent8.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor9Ml.Text = percent9.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);
            Flavor10Ml.Text = percent10.ToMl(targetVol).ToString(CultureInfo.CurrentCulture);

            PGGrams.Text = GetGramsForType(PGMl.Text, 2).ToString(CultureInfo.CurrentCulture);
            VGGrams.Text = GetGramsForType(VGMl.Text, 1).ToString(CultureInfo.CurrentCulture);
            Flavor1Grams.Text = GetGramsForType(Flavor1Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor2Grams.Text = GetGramsForType(Flavor2Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor3Grams.Text = GetGramsForType(Flavor3Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor4Grams.Text = GetGramsForType(Flavor4Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor5Grams.Text = GetGramsForType(Flavor5Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor6Grams.Text = GetGramsForType(Flavor6Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor7Grams.Text = GetGramsForType(Flavor7Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor8Grams.Text = GetGramsForType(Flavor8Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor9Grams.Text = GetGramsForType(Flavor9Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            Flavor10Grams.Text = GetGramsForType(Flavor10Ml.Text, 4).ToString(CultureInfo.CurrentCulture);
            NicotineGrams.Text = GetGramsForType(NicotineMl.Text, 3).ToString(CultureInfo.CurrentCulture);
        }

        private static double GetDifferencePGTotal(List<Flavor> flavors, double pgPercent, double nicPg,
            double nicPercent)
        {
            var pgSum = pgPercent;
            foreach (var flavor in flavors)
            {
                pgSum -= flavor.GetPG() * (flavor.GetPercentToUse() / 100);
            }

            pgSum -= (nicPercent / 100 * nicPg);

            var messageDialog = new MessageDialog(
                "You need to add more PG. Cannot use negative numbers as shown. You might have received this error because your desired PG ratio is lower than the amount contained in your ingredients.",
                "Add more PG");
            if (pgSum.CompareTo(0) < 0)
            {
                messageDialog.ShowAsync();
            }

            return pgSum;
        }

        private static double GetDifferenceVGTotal(List<Flavor> flavors, double vgPercent, double nicVg,
            double nicPercent)
        {
            var vgSum = vgPercent;
            foreach (var flavor in flavors)
            {
                vgSum -= 100 - flavor.GetPG();
            }

            vgSum -= (nicPercent / 100 * nicVg);

            var messageDialog = new MessageDialog(
                "You need to add more VG. Cannot use negative numbers as shown. You might have received this error because your desired VG ratio is lower than the amount contained in your ingredients.",
                "Add more VG");
            if (vgSum.CompareTo(0) < 0)
            {
                messageDialog.ShowAsync();
            }

            return vgSum;
        }

        private static double GetSumByColumn(Grid grid, List<int> rowsExcluded, int column) =>
            (from TextBlock child in grid.Children
                where rowsExcluded.IndexOf(Grid.GetRow(child)) == -1 && Grid.GetColumn(child) == column
                select child.QuickParse()).Sum();

        /// <summary>
        /// GetGramsForType takes two values:
        ///     The amount of the ingredient used (in milliliters) as a string (for now),
        ///     And the type of ingredient used (all types will have a specific, corresponding integer value).
        /// </summary>
        /// <param name="ingredientMl">
        /// This is (currently) passed as a string because it should make the usage of this method shorter, and less complicated
        /// </param>
        /// <param name="ingredientType">
        /// The possible values are (currently):
        ///     "1": VG
        ///     "2": PG
        ///     "3": Nicotine
        ///     "4": Flavor
        /// </param>
        /// <returns>
        /// The amount of the ingredient used (in grams) as a double (for now).
        /// </returns>
        private static double GetGramsForType(string ingredientMl, int ingredientType)
        {
            switch (ingredientType)
            {
                case 1:
                    //TODO: Do VG calculation
                    return double.Parse(ingredientMl) * _vgGrams;
                case 2:
                    //TODO: Do PG calculation
                    return double.Parse(ingredientMl) * _pgGrams;
                case 3:
                    //TODO: Do Nicotine calculation
                    return double.Parse(ingredientMl) * _nicGrams;
                case 4:
                    //TODO: Do Flavor calculation
                    return double.Parse(ingredientMl) * _flavoringGrams;
                default:
                    //TODO: Do no calculations
                    return 0;
            }
        }
    }
}