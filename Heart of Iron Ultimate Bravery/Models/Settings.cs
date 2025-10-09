using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Heart_of_Iron_Ultimate_Bravery.Assets.Localization;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models
{
  public class Settings : ISettings
  {
    public Settings()
    {
      using (StreamReader file = File.OpenText("./Data/settings.json"))
      using (var reader = new JsonTextReader(file))
      {
        var rawData = (JObject)JToken.ReadFrom(reader);
        Language = rawData.GetValue("lang")?.ToString() ?? string.Empty;
        GamePath = rawData.GetValue("gamePath")?.ToString() ?? string.Empty;
        CurrentMod = new Mod(rawData.GetValue("mod")?.ToString());
        ModPath = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawData.GetValue("modPath").ToString());
      }
    }

    public string Language { get; set; }

    public string GamePath { get; set; }

    public Mod CurrentMod { get; set; }

    public Dictionary<string, string> ModPath { get; set; }

    public void SetLanguage(string language)
    {
      try
      {
        Language = language;
        UpdateData();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void SetGamePath(string path = "test")
    {
      try
      {
        GamePath = path;
        UpdateData();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void SetMod(string mod)
    {
      try
      {
        CurrentMod = new Mod(mod);
        CurrentMod.AddCountries();
        UpdateData();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public void SetModPath(string path)
    {
      try
      {
        ModPath[CurrentMod.Short] = path;
        UpdateData();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    private void UpdateData()
    {
      try
      {
        object test = new
        {
          lang = Language, gamePath = GamePath, mod = CurrentMod.Short, modPath = ModPath,
        };
        using (StreamWriter file = File.CreateText(@"./Data/settings.json"))
        {
          var serializer = new JsonSerializer();
          serializer.Serialize(file, test);
        }

        Resources.Culture = new CultureInfo(Language);
        MainWindowViewModel? currentWindow = ServiceCollectionExtensions.GetService<MainWindowViewModel>();
        currentWindow.UpdateView();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}