using System;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;
using Microsoft.Extensions.DependencyInjection;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection _collection = new ServiceCollection();
    private static IServiceProvider _serviceProvider = null!;
    
    private static GenerateViewModel? _generateViewModel = null;
    private static SettingsViewModel? _settingsViewModel = null;
    private static MultiplayerViewModel? _multiplayerViewModel = null;
    private static ExportViewModel? _exportViewModel = null; // Optional
    private static UnitGenerationViewModel? _unitGenerationViewModel = null;
    
    public static void AddCommonServices()
    {
        _collection.AddSingleton<Settings, Settings>();
        _collection.AddSingleton<WindowsManagement, WindowsManagement>();
        _collection.AddSingleton<MainWindowViewModel, MainWindowViewModel>();
        _collection.AddSingleton<GenerateViewModel, GenerateViewModel>();
        _collection.AddSingleton<LocalizationFactory, LocalizationFactory>();
        _serviceProvider = _collection.BuildServiceProvider();
    }
    
    public static T? GetService<T>() 
    {
        // Lazy singletons for ViewModels
        if (typeof(T) == typeof(GenerateViewModel))
        {
            _generateViewModel ??= new GenerateViewModel();
            return (T)(object)_generateViewModel;
        }
        
        if (typeof(T) == typeof(SettingsViewModel))
        {
            _settingsViewModel ??= new SettingsViewModel();
            return (T)(object)_settingsViewModel;
        }
        
        if (typeof(T) == typeof(MultiplayerViewModel))
        {
            _multiplayerViewModel ??= new MultiplayerViewModel();
            return (T)(object)_multiplayerViewModel;
        }
        
        if (typeof(T) == typeof(ExportViewModel))
        {
            _exportViewModel ??= new ExportViewModel();
            return (T)(object)_exportViewModel;
        }
        
        if (typeof(T) == typeof(UnitGenerationViewModel))
        {
            _unitGenerationViewModel ??= new UnitGenerationViewModel();
            return (T)(object)_unitGenerationViewModel;
        }
        
        return _serviceProvider.GetService<T>();
    }
}