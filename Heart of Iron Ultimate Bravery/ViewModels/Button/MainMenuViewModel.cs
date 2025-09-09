using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class MainMenuViewModel : ViewModelBase
{
    
    [RelayCommand]
    public void OpenGenerateWindow()
    {
        IWindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<IWindowsManagement>()!;
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.GenerateExport] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.SetNewButtonBlock();
    }
    
    [RelayCommand]
    public void OpenExportWindow()
    {
        IWindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<IWindowsManagement>()!;
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.GenerateExport] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.SetNewButtonBlock();
    }
    
    [RelayCommand]
    public void OpenMultiplayerWindow()
    {
        IWindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<IWindowsManagement>()!;
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.Multiplayer] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.SetNewButtonBlock();
    }

    [RelayCommand]
    public void OpenSettingsWindow()
    {
        IWindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<IWindowsManagement>()!;
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.Settings] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.SetNewButtonBlock();
    }
    
    [RelayCommand]
    public void OpenQuitWindow()
    {
        Environment.Exit(0);
    }
}