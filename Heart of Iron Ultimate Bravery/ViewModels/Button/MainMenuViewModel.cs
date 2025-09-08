using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class MainMenuViewModel : ViewModelBase
{
    

    [RelayCommand]
    public async Task OpenSettingsWindow()
    {
        Console.WriteLine("OpenSettingsWindow");
    }
    
    [RelayCommand]
    public async Task OpenQuitWindow()
    {
        Environment.Exit(0);
    }
}