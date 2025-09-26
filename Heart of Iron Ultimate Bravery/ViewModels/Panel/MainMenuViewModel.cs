using Heart_of_Iron_Ultimate_Bravery.Models;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public class MainMenuViewModel : PanelViewModelBase
{
    private string _modName;
    private string _modVersion;
    
    
    public MainMenuViewModel()
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        ModName = settings.CurrentMod.Name;
        ModVersion = settings.CurrentMod.Version;
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
}