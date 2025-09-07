using System.Globalization;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.Views;

namespace Heart_of_Iron_Ultimate_Bravery;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        using (StreamReader file = File.OpenText("./Data/settings.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject rawData = (JObject)JToken.ReadFrom(reader);
            string lang = rawData.GetValue("lang")?.ToString() ?? string.Empty;
            string gamePath = rawData.GetValue("gamePath")?.ToString() ?? string.Empty;
            Mod mod = new Mod(rawData.GetValue("mod")?.ToString());
            Settings settings = new Settings(lang, gamePath, mod);
            Assets.Localization.Resources.Culture = new CultureInfo(lang);
        }
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}