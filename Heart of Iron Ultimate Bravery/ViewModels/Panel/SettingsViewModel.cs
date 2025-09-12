using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public partial class SettingsViewModel : PanelViewModelBase
{
    public SettingsViewModel()
    {
        Console.WriteLine(_guid);
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!;
        Lang = settings.Language;
        GamePath = settings.GamePath;
        Mod = settings.CurrentMod;

        int langIndex = 0;
        using (StreamReader file = File.OpenText("./Data/langs.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject rawData = (JObject)JToken.ReadFrom(reader);
            List<JToken> langs = rawData.Children().ToList();
            foreach (var jToken in langs)
            {
                Language lang= jToken.First.ToObject<Language>();
                CbLangsString.Add(Assets.Localization.Resources.ResourceManager.GetString($"{lang.Name}Text"));
                if (Lang == lang.Local)
                {
                    CbLangsIndex = langIndex;
                }
                langIndex++;
            }
        }
        
        int modIndex = 0;
        using  (StreamReader file = File.OpenText("./Data/mods.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject rawData = (JObject)JToken.ReadFrom(reader);
            List<JToken> mods = rawData.Children().ToList();
            foreach (var jToken in mods)
            {
                Mod mod = jToken.First.ToObject<Mod>();
                CbModsString.Add(mod.Name);
                if (Mod.Name == mod.Name)
                {
                    CbModsIndex = modIndex;
                }
                modIndex++;
            }
        }
        Console.WriteLine(CbModsIndex.GetTypeCode() + " " + _modsIndex.GetTypeCode());
        // Console.WriteLine(Assets.Localization.Resources.ResourceManager.GetString("SettingsText"));
    }

    Guid _guid = Guid.NewGuid();
    private string? _lang;
    private string? _gamePath;
    private Mod? _mod;
    private List<string>? _langsString = new();
    private int _langsIndex;
    private List<string>? _modsString = new();
    private int _modsIndex;
    
    public string? Lang
    {
        get { return _lang; }
        private set { this.RaiseAndSetIfChanged(ref _lang, value); }
    }
    
    public string? GamePath
    {
        get { return _gamePath; }
        private set { this.RaiseAndSetIfChanged(ref _gamePath, value); }
    }
    
    public Mod? Mod
    {
        get { return _mod; }
        private set { this.RaiseAndSetIfChanged(ref _mod, value); }
    }
    
    public List<string>? CbLangsString
    {
        get { return _langsString; }
        private set { this.RaiseAndSetIfChanged(ref _langsString, value); }
    }
    
    public int CbLangsIndex
    {
        get { return _langsIndex; }
        private set { this.RaiseAndSetIfChanged(ref _langsIndex, value); }
    }

    public List<string>? CbModsString
    {
        get { return _modsString; }
        private set { this.RaiseAndSetIfChanged(ref _modsString, value); }
    }

    public int CbModsIndex
    {
        get { return _modsIndex; }
        private set { this.RaiseAndSetIfChanged(ref _modsIndex, value); }
    }

    [RelayCommand]
    public void SaveSettings()
    {
        Console.WriteLine(_guid);
        //Console.WriteLine(CbLangsIndex.GetTypeCode() + " " + _langsIndex.GetTypeCode());
        Console.WriteLine(CbModsIndex.GetTypeCode() + " " + _modsIndex.GetTypeCode());
    }
}