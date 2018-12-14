using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuiceTime.Views;
using Newtonsoft.Json;

namespace JuiceTime
{
    public class Recipe
    {
        [JsonProperty] private double NicPGToVG;
        [JsonProperty] private double NicStrength;
        [JsonProperty] private double TargetStrength;
        [JsonProperty] private double TargetVolume;
        [JsonProperty] private double TargetPGToVG;
        [JsonProperty] private List<Flavor> Flavors;
        [JsonProperty] private string Notes;
        [JsonProperty] private double WaterVodkaPGA;

        public Recipe(double nicPgtoVg, double nicStrength, double targetStrength, double targetVolume, double targetPgtoVg, List<Flavor> flavors, String notes, double waterVodkaPga)
        {
            NicPGToVG = nicPgtoVg;
            NicStrength = nicStrength;
            TargetStrength = targetStrength;
            TargetVolume = targetVolume;
            TargetPGToVG = targetPgtoVg;
            Flavors = flavors;
            Notes = notes;
            WaterVodkaPGA = waterVodkaPga;
        }

        public double GetVolume()
        {
            return this.TargetVolume;
        }

        public void Deconstruct(out double nicPgtoVg, out double nicStrength, out double targetStrength, out double targetVolume, out double targetPgtoVg, out List<Flavor> flavors, out string notes, out double waterVodkaPga)
        {
            nicPgtoVg = NicPGToVG;
            nicStrength = NicStrength;
            targetStrength = TargetStrength;
            targetVolume = TargetVolume;
            targetPgtoVg = TargetPGToVG;
            flavors = Flavors;
            notes = Notes;
            waterVodkaPga = WaterVodkaPGA;
        }
    }
}
