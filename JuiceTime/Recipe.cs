using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JuiceTime
{
    public class Recipe
    {
        [JsonProperty] private readonly double _nicPgtoVG;
        [JsonProperty] private readonly double _nicStrength;
        [JsonProperty] private readonly double _targetStrength;
        [JsonProperty] private readonly double _targetVolume;
        [JsonProperty] private readonly double _targetPgtoVG;
        [JsonProperty] private readonly List<Flavor> _flavors;
        [JsonProperty] private readonly string _notes;
        [JsonProperty] private readonly double _waterVodkaPga;

        public Recipe(double nicPgtoVg, double nicStrength, double targetStrength, double targetVolume, double targetPgtoVg, List<Flavor> flavors, String notes, double waterVodkaPga)
        {
            _nicPgtoVG = nicPgtoVg;
            _nicStrength = nicStrength;
            _targetStrength = targetStrength;
            _targetVolume = targetVolume;
            _targetPgtoVG = targetPgtoVg;
            _flavors = flavors;
            _notes = notes;
            _waterVodkaPga = waterVodkaPga;
        }

        public double GetVolume() => _targetVolume;

        public void Deconstruct(out double nicPgtoVg, out double nicStrength, out double targetStrength, out double targetVolume, out double targetPgtoVg, out List<Flavor> flavors, out string notes, out double waterVodkaPga)
        {
            nicPgtoVg = _nicPgtoVG;
            nicStrength = _nicStrength;
            targetStrength = _targetStrength;
            targetVolume = _targetVolume;
            targetPgtoVg = _targetPgtoVG;
            flavors = _flavors;
            notes = _notes;
            waterVodkaPga = _waterVodkaPga;
        }
    }
}
