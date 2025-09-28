using Heart_of_Iron_Ultimate_Bravery.Models;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public class MainMenuViewModel : PanelViewModelBase
{
    private string _modName;
    private string _modVersion;
    private string _activatedModName;
    private string _activatedModVersion;
    
    public MainMenuViewModel()
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        ModName = settings.CurrentMod.Name;
        ModVersion = settings.CurrentMod.Version;
        string label = Assets.Localization.Resources.ResourceManager.GetString($"ModActivatedText");
        ActivatedModName = label + ModName;
        ActivatedModVersion = "Version: " + ModVersion;
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