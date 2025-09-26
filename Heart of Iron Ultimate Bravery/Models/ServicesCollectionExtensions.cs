using System;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection _collection = new ServiceCollection();
    private static IServiceProvider _serviceProvider = null!;
    public static void AddCommonServices()
    {
        _collection.AddSingleton<Settings, Settings>();
        _collection.AddSingleton<IWindowsManagement, WindowsManagement>();
        _collection.AddSingleton<MainWindowViewModel, MainWindowViewModel>();
        _serviceProvider = _collection.BuildServiceProvider();
    }
    
    public static T? GetService<T>() 
    {
        return _serviceProvider.GetService<T>();
    }
}