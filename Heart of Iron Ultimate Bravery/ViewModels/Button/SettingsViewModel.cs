using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class SettingsViewModel : ButtonBlockViewModelBase
{
    
    [RelayCommand]
    public void OpenMainMenuWindow()
    {
        IWindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<IWindowsManagement>()!;
        windowsManagement.Buttons[WindowType.Settings] = false;
        windowsManagement.Buttons[WindowType.MainMenu] = true;
        windowsManagement.Panels[WindowType.Settings] = false;
        windowsManagement.Panels[WindowType.MainMenu] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }
}