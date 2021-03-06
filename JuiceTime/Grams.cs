﻿using System.Globalization;
using Newtonsoft.Json;

namespace JuiceTime
{
    class Grams
    {
        [JsonProperty] private double _nicGrams;
        [JsonProperty] private double _pgGrams;
        [JsonProperty] private double _vgGrams;
        [JsonProperty] private double _waterGrams;
        [JsonProperty] private double _flavorGrams;

        public Grams(double nicGrams, double pgGrams, double vgGrams, double waterGrams, double flavorGrams)
        {
            _nicGrams = nicGrams;
            _pgGrams = pgGrams;
            _vgGrams = vgGrams;
            _waterGrams = waterGrams;
            _flavorGrams = flavorGrams;
        }

        public void Deconstruct(out double nicGrams, out double pgGrams, out double vgGrams, out double waterGrams, out double flavorGrams)
        {
            nicGrams = _nicGrams;
            pgGrams = _pgGrams;
            vgGrams = _vgGrams;
            waterGrams = _waterGrams;
            flavorGrams = _flavorGrams;
        }
        
        /// <summary>
        /// This deconstructor gives the values as strings. Note: it requires a 6th variable assignment for C# to distinguish it from the other deconstructor (disposal variable works fine)
        /// </summary>
        /// <param name="nicGrams"></param>
        /// <param name="pgGrams"></param>
        /// <param name="vgGrams"></param>
        /// <param name="waterGrams"></param>
        /// <param name="flavorGrams"></param>
        /// <param name="filler"></param>
        public void Deconstruct(out string nicGrams, out string pgGrams, out string vgGrams, out string waterGrams,
            out string flavorGrams, out string filler)
        {
            nicGrams = _nicGrams.ToString(CultureInfo.CurrentCulture);
            pgGrams = _pgGrams.ToString(CultureInfo.CurrentCulture);
            vgGrams = _vgGrams.ToString(CultureInfo.CurrentCulture);
            waterGrams = _waterGrams.ToString(CultureInfo.CurrentCulture);
            flavorGrams = _flavorGrams.ToString(CultureInfo.CurrentCulture);
            filler = "";
        }

    }
}
