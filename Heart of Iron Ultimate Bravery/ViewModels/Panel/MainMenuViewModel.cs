using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Avalonia.Media.Imaging;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public class MainMenuViewModel : PanelViewModelBase
{
    private string _modName;
    private string _modVersion;
    private string _activatedModName;
    private string _activatedModVersion;
    public Bitmap ActivatedModIconBitmap { get; set; }

    public ObservableCollection<RoadMapItem> RoadMap { get; set; } = new();
    
    public MainMenuViewModel()
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        ModName = settings.CurrentMod.Name;
        ModVersion = settings.CurrentMod.Version;
        string label = Assets.Localization.Resources.ResourceManager.GetString($"ModActivatedText");
        ActivatedModName = label + ModName;
        ActivatedModVersion = "Version: " + ModVersion;
        var modFiles = Directory.GetFiles(@$"./Assets/Mods/{ModName}/Images", "*game-icon*");
        var modFile = modFiles[0];
        ActivatedModIconBitmap = ImageHelper.LoadFromResource(modFile);
        
        
        string fileName = $"Data/mods.json";
        string jsonString = File.ReadAllText(fileName);
        JsonObject jsonData = JsonSerializer.Deserialize<JsonObject>(jsonString)!;
        JsonObject modData = JsonSerializer.Deserialize<JsonObject>(jsonData[settings.CurrentMod.Short]);

        foreach (var value in JsonSerializer.Deserialize<List<RoadMapItem>>(modData["roadMap"]))
        {
            string name = value.Name;
            string completion = value.Completion;
            RoadMap.Add(new RoadMapItem(name, completion, "0,0,0,0"));
            if (value.Tasks == null) continue;
            foreach (RoadMapItem roadMapItem in value.Tasks)
            {
                RoadMap.Add(new RoadMapItem(roadMapItem.Name, roadMapItem.Completion, "50,0,0,0"));
            }
        }
    }

    public string ModName
    {
        get { return _modName; }
        private set { this.RaiseAndSetIfChanged(ref _modName, value); }
    }

    public string ModVersion
    {
        get { return _modVersion; }
        private set { this.RaiseAndSetIfChanged(ref _modVersion, value); }
    }

    public string ActivatedModName
    {
        get { return _activatedModName; }
        private set { this.RaiseAndSetIfChanged(ref _activatedModName, value); }
    }

    public string ActivatedModVersion
    {
        get { return _activatedModVersion; }
        private set { this.RaiseAndSetIfChanged(ref _activatedModVersion, value); }
    }
}