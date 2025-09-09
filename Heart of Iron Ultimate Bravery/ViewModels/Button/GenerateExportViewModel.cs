using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class GenerateExportViewModel : ViewModelBase
{
    
    [RelayCommand]
    public void OpenShipWindow()
    {}
    
    [RelayCommand]
    public void OpenTankWindow()
    {}
    
    [RelayCommand]
    public void OpenPlaneWindow()
    {}
    
    [RelayCommand]
    public void OpenDivisionWindow()
    {}
    
    [RelayCommand]
    public void OpenDoctrinesWindow()
    {}

    [RelayCommand]
    public void OpenMainMenuWindow()
    {
        IWindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<IWindowsManagement>()!;
        windowsManagement.Buttons[WindowType.GenerateExport] = false;
        windowsManagement.Buttons[WindowType.MainMenu] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.SetNewButtonBlock();
    }
}