using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models
{
  public class Mod
  {
    public Mod()
    {
    }

    public Mod(string? name)
    {
      using (StreamReader file = File.OpenText("./Data/mods.json"))
      using (JsonTextReader reader = new JsonTextReader(file))
      {
        JObject rawData = (JObject)JToken.ReadFrom(reader);
        JObject? modData = rawData.GetValue(name)!.Value<JObject>();
        Name = modData?["name"]?.ToString() ?? "Vanilla";
        Version = modData?["version"]?.ToString() ?? "0.0.0";
        SteamId = BigInteger.Parse(modData?["steamId"]?.ToString()!);
        Short = name ?? "vanilla";
      }
    }

    public string? Name { get; set; }

    public BigInteger SteamId { get; set; }

    public string? Short { get; set; }

    public string? Version { get; set; }

    public List<Country> Countries { get; set; } = new();

    public void AddCountries()
    {
      // string countriesPath = $"./Data/Mods/{Name}/Files/Game/countries.json";
      string countriesPath = $"./Data/Mods/Vanilla/Files/Game/countries.json";
      using (StreamReader file = File.OpenText(countriesPath))
      using (JsonTextReader reader = new JsonTextReader(file))
      {
        JArray rawData = (JArray)JToken.ReadFrom(reader);
        foreach (JToken jCountry in rawData)
        {
          if (jCountry["name"]?.ToString() != string.Empty)
          {
            Country country = new Country(jCountry);
            Countries.Add(country);
          }
        }
      }
    }
  }
}