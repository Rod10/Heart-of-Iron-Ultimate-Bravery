using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class MultiplayerViewModel : ButtonBlockViewModelBase
{
    [RelayCommand]
    public void OpenJoinWindow() {}
    
    [RelayCommand]
    public void OpenCreateWindow() {}
    
    [RelayCommand]
    public void OpenMainMenuWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        windowsManagement.Buttons[WindowType.Multiplayer] = false;
        windowsManagement.Buttons[WindowType.MainMenu] = true;
        windowsManagement.Panels[WindowType.Multiplayer] = false;
        windowsManagement.Panels[WindowType.MainMenu] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }
}