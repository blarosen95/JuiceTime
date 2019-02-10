using Newtonsoft.Json;

namespace JuiceTime
{
    public class Flavor
    {
        [JsonProperty]
        private string _brand;
        [JsonProperty]
        private string _name;
        [JsonProperty]
        private double _pgtoVG;
        [JsonProperty]
        private double _percentToUse;

        public Flavor(string brand, string name, double pgtoVg, double percentToUse)
        {
            _brand = brand;
            _name = name;
            _pgtoVG = pgtoVg;
            _percentToUse = percentToUse;
        }

        public void Deconstruct(out string brand, out string name, out double pgtoVg, out double percentToUse)
        {
            brand = _brand;
            name = _name;
            pgtoVg = _pgtoVG;
            percentToUse = _percentToUse;
        }

        public double GetPG() => _pgtoVG;
        public double GetPercentToUse() => _percentToUse;

    }
}
