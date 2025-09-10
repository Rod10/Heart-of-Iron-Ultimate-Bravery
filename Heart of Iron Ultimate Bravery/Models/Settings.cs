using System.IO;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Settings : ISettings
{
    public string Language { get; set; }
    public string GamePath { get; set; }
    public Mod CurrentMod { get; set; }

    public Settings()
    {
        using (StreamReader file = File.OpenText("./Data/settings.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject rawData = (JObject)JToken.ReadFrom(reader);
            Language = rawData.GetValue("lang")?.ToString() ?? string.Empty;
            GamePath = rawData.GetValue("gamePath")?.ToString() ?? string.Empty;
            CurrentMod = new Mod(rawData.GetValue("mod")?.ToString());
        }
    }
    
    public bool SetLanguage(string language)
    {
        throw new System.NotImplementedException();
    }
    public bool SetGamePath(string path)
    {
        throw new System.NotImplementedException();
    }

    public bool SetMod(string mod)
    {
        throw new System.NotImplementedException();
    }
}