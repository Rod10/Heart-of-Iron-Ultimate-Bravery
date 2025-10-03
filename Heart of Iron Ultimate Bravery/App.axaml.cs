using System;
using System.Globalization;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Heart_of_Iron_Ultimate_Bravery.Assets.Mods.Vanilla.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Heart_of_Iron_Ultimate_Bravery;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ServiceCollectionExtensions.AddCommonServices();
        Settings settings = ServiceCollectionExtensions.GetService<Settings>() ?? new Settings();
        settings.CurrentMod.AddCountries();
        Assets.Localization.Resources.Culture = new CultureInfo(settings.Language);
        LocalizationFactory locFactory = ServiceCollectionExtensions.GetService<LocalizationFactory>();
        locFactory.SetCulture(settings.CurrentMod, new CultureInfo(settings.Language));
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            // DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = ServiceCollectionExtensions.GetService<MainWindowViewModel>(),
            };
            desktop.MainWindow.Width = 1280;
            desktop.MainWindow.Height = 720;
        }
        base.OnFrameworkInitializationCompleted();
    }

    /*private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }*/
}