using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JuiceTime
{
    class Grams
    {
        [JsonProperty] private double NicGrams;
        [JsonProperty] private double PGGrams;
        [JsonProperty] private double VGGrams;
        [JsonProperty] private double WaterGrams;
        [JsonProperty] private double FlavorGrams;

        public Grams(double nicGrams, double pgGrams, double vgGrams, double waterGrams, double flavorGrams)
        {
            NicGrams = nicGrams;
            PGGrams = pgGrams;
            VGGrams = vgGrams;
            WaterGrams = waterGrams;
            FlavorGrams = flavorGrams;
        }

        public void Deconstruct(out double nicGrams, out double pgGrams, out double vgGrams, out double waterGrams, out double flavorGrams)
        {
            nicGrams = NicGrams;
            pgGrams = PGGrams;
            vgGrams = VGGrams;
            waterGrams = WaterGrams;
            flavorGrams = FlavorGrams;
        }

        public void Deconstruct(out string nicGrams, out string pgGrams, out string vgGrams, out string waterGrams,
            out string flavorGrams, out string filler)
        {
            nicGrams = NicGrams.ToString();
            pgGrams = PGGrams.ToString();
            vgGrams = VGGrams.ToString();
            waterGrams = WaterGrams.ToString();
            flavorGrams = FlavorGrams.ToString();
            filler = "";
        }

    }
}
