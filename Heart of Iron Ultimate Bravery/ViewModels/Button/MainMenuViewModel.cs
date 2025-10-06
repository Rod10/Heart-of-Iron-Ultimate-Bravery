using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class MainMenuViewModel : ButtonBlockViewModelBase
{
    
    [RelayCommand]
    public void OpenGenerateWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.GenerateExport] = true;
        windowsManagement.Panels[WindowType.MainMenu] = false;
        windowsManagement.Panels[WindowType.Generate] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }
    
    [RelayCommand]
    public void OpenExportWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.GenerateExport] = true;
        windowsManagement.Panels[WindowType.MainMenu] = false;
        windowsManagement.Panels[WindowType.Export] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }
    
    [RelayCommand]
    public void OpenMultiplayerWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.Multiplayer] = true;
        windowsManagement.Panels[WindowType.MainMenu] = false;
        windowsManagement.Panels[WindowType.Multiplayer] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }

    [RelayCommand]
    public void OpenSettingsWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        windowsManagement.Buttons[WindowType.MainMenu] = false;
        windowsManagement.Buttons[WindowType.Settings] = true;
        windowsManagement.Panels[WindowType.MainMenu] = false;
        windowsManagement.Panels[WindowType.Settings] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }
    
    [RelayCommand]
    public void OpenQuitWindow()
    {
        Environment.Exit(0);
    }
}