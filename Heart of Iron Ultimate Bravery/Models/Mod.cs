using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Mod
{
    public string Name { get; set; }
    public BigInteger SteamId { get; set; }
    public string Short { get; set; }
    public List<Country> countries { get; set; }

    public Mod() {}

    public Mod(string? name)
    {
        using (StreamReader file = File.OpenText("./Data/mods.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject rawData = (JObject)JToken.ReadFrom(reader);
            JObject? modData = rawData.GetValue(name)!.Value<JObject>();
            Name = modData?["name"]?.ToString() ?? "Vanilla";
            SteamId = BigInteger.Parse(modData?["steamId"]?.ToString()!);
            Short = name ?? "vanilla";
        }
    }

    public void AddCountries()
    {
        // string countriesPath = $"./Data/Mods/{Name}/Files/Game/countries.json";
        string countriesPath = $"./Data/Mods/Vanilla/Files/Game/countries.json";
        using (StreamReader file = File.OpenText(countriesPath))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JArray rawData = (JArray)JToken.ReadFrom(reader);
            foreach (JToken? jCountry in rawData)
            {
                if (jCountry["name"]?.ToString() != "")
                {
                    Country country = new Country(jCountry);
                    // countries.Add(country);
                }
            }
        }
    }
}