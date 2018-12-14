using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JuiceTime.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalculatePage : Page
    {
        //TODO: replace the use of a field containing this app's instance of the RecipePage with a more conventional/functional approach
        private Recipe _recipe;

        public CalculatePage(Recipe recipe)
        {
            this.InitializeComponent();
            this._recipe = recipe;
        }

        //Called every time the user loads the CalculatePage as the view
        public void CalculateValues()
        {
            //TODO: Perform calculations using RecipePage's data
            //Do here
            var(pgNic, nicStr, targetStr, targetVol, targetPg, flavors, notes, waterVodkaPga) = _recipe;
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
            NicotineMl.Text = (targetStr * targetVol / nicStr).ToString();

            NicotinePercent.Text = (NicotineMl.QuickParse()/targetVol * 100).ToString();
            PGPercent.Text = GetDifferencePGTotal(flavors, targetPg, pgNic, NicotinePercent.QuickParse()).ToString();
            VGPercent.Text = GetDifferenceVGTotal(flavors, 100 - targetPg, 100 - pgNic, NicotinePercent.QuickParse()).ToString();
            WaterPercent.Text = waterVodkaPga.ToString();
            Flavor1Percent.Text = percent1.ToString();
            Flavor2Percent.Text = percent2.ToString();
            Flavor3Percent.Text = percent3.ToString();
            Flavor4Percent.Text = percent4.ToString();
            Flavor5Percent.Text = percent5.ToString();
            Flavor6Percent.Text = percent6.ToString();
            Flavor7Percent.Text = percent7.ToString();
            Flavor8Percent.Text = percent8.ToString();
            Flavor9Percent.Text = percent9.ToString();
            Flavor10Percent.Text = percent10.ToString();
            TotalPercent.Text = GetSumByColumn(CalcGrid, List.Of(0, 1, 16), 3).ToString();

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

            PGMl.Text = PGPercent.QuickParse().ToMl(targetVol).ToString();
            VGMl.Text = VGPercent.QuickParse().ToMl(targetVol).ToString();
            Flavor1Ml.Text = percent1.ToMl(targetVol).ToString();
            Flavor2Ml.Text = percent2.ToMl(targetVol).ToString();
            Flavor3Ml.Text = percent3.ToMl(targetVol).ToString();
            Flavor4Ml.Text = percent4.ToMl(targetVol).ToString();
            Flavor5Ml.Text = percent5.ToMl(targetVol).ToString();
            Flavor6Ml.Text = percent6.ToMl(targetVol).ToString();
            Flavor7Ml.Text = percent7.ToMl(targetVol).ToString();
            Flavor8Ml.Text = percent8.ToMl(targetVol).ToString();
            Flavor9Ml.Text = percent9.ToMl(targetVol).ToString();
            Flavor10Ml.Text = percent10.ToMl(targetVol).ToString();

        }
        
        private static double GetDifferencePGTotal(List<Flavor> flavors, double pgPercent, double nicPg, double nicPercent)
        {
            double pgSum = pgPercent;
            foreach (Flavor flavor in flavors)
            {
                pgSum -= flavor.GetPG() * (flavor.GetPercentToUse() / 100);
            }

            pgSum -= (nicPercent / 100 * nicPg);

            var messageDialog = new MessageDialog("You need to add more PG. Cannot use negative numbers as shown. You might have received this error because your desired PG ratio is lower than the amount contained in your ingredients.", "Add more PG");
            if (pgSum.CompareTo(0) < 0)
            {
                messageDialog.ShowAsync();
            }

            return pgSum;
        }

        private static double GetDifferenceVGTotal(List<Flavor> flavors, double vgPercent, double nicVg,
            double nicPercent)
        {
            double vgSum = vgPercent;
            foreach (Flavor flavor in flavors)
            {
                vgSum -= 100 - flavor.GetPG();
            }

            vgSum -= (nicPercent / 100 * nicVg);

            var messageDialog = new MessageDialog("You need to add more VG. Cannot use negative numbers as shown. You might have received this error because your desired VG ratio is lower than the amount contained in your ingredients.", "Add more VG");
            if (vgSum.CompareTo(0) < 0)
            {
                messageDialog.ShowAsync();
            }

            return vgSum;
        }

        private static double GetSumByColumn(Grid grid, List<int> rowsExcluded, int column) => (from TextBlock child in grid.Children where rowsExcluded.IndexOf(Grid.GetRow(child)) == -1 && Grid.GetColumn(child) == column select child.QuickParse()).Sum();
    }
}
