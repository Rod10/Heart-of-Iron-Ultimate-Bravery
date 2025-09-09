using System;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection _collection;
    private static IServiceProvider _serviceProvider;
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<ISettings, Settings>();
        collection.AddSingleton<IWindowsManagement, WindowsManagement>();
        collection.AddSingleton<MainWindowViewModel, MainWindowViewModel>();
        _collection = collection;
        _serviceProvider = _collection.BuildServiceProvider();
    }
    
    public static T? GetService<T>() 
    {
        return _serviceProvider.GetService<T>();
    }
}