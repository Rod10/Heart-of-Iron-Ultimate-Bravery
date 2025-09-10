using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Mod
{
    public string Name {  get; set; }
    public int SteamId { get; set; }
    // public List<Country> countries { get; set; } 

    public Mod() {}
    
    public Mod(string? name)
    {
        using (StreamReader file = File.OpenText("./Data/mods.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject rawData = (JObject)JToken.ReadFrom(reader);
            JObject? modData = rawData.GetValue(name)!.Value<JObject>();
            Name = modData?["name"]?.ToString() ?? string.Empty;
            SteamId = int.Parse(modData?["steamId"]?.ToString()!);
        }
    }
}