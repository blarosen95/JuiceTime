using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JuiceTime
{
    public class Flavor
    {
        [JsonProperty]
        private string Brand;
        [JsonProperty]
        private string Name;
        [JsonProperty]
        private double PGToVG;
        [JsonProperty]
        private double PercentToUse;

        public Flavor(string brand, string name, double pgtoVg, double percentToUse)
        {
            Brand = brand;
            Name = name;
            PGToVG = pgtoVg;
            PercentToUse = percentToUse;
        }

        public void Deconstruct(out string brand, out string name, out double pgtoVg, out double percentToUse)
        {
            brand = Brand;
            name = Name;
            pgtoVg = PGToVG;
            percentToUse = PercentToUse;
        }

        public double GetPG() => PGToVG;
        public double GetPercentToUse() => PercentToUse;

    }
}
