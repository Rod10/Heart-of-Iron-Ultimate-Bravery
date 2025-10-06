using System;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;
using Heart_of_Iron_Ultimate_Bravery.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection _collection = new ServiceCollection();
    private static IServiceProvider _serviceProvider = null!;
    private static GenerateViewModel? _generateViewModel = null;
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
        // Special case for GenerateViewModel
        if (typeof(T) == typeof(GenerateViewModel))
        {
            if (_generateViewModel == null)
            {
                _generateViewModel = new GenerateViewModel();
            }
            return (T)(object)_generateViewModel;
        }
        
        return _serviceProvider.GetService<T>();
    }
}