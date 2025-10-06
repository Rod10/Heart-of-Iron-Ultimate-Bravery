using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class GenerateExportViewModel : ButtonBlockViewModelBase
{
    
    [RelayCommand]
    public void OpenShipWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        GenerateViewModel generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
        windowsManagement.UnitType = UnitType.Ship;
        generateViewModel.UpdateView();
    }
    
    [RelayCommand]
    public void OpenTankWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        GenerateViewModel generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
        windowsManagement.UnitType = UnitType.Tank;
        generateViewModel.UpdateView();
    }
    
    [RelayCommand]
    public void OpenPlaneWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        GenerateViewModel generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
        windowsManagement.UnitType = UnitType.Plane;
        generateViewModel.UpdateView();
    }
    
    [RelayCommand]
    public void OpenDivisionWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        GenerateViewModel generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
        windowsManagement.UnitType = UnitType.Division;
        generateViewModel.UpdateView();
    }
    
    [RelayCommand]
    public void OpenDoctrinesWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        GenerateViewModel generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
        windowsManagement.UnitType = UnitType.Doctrine;
        generateViewModel.UpdateView();
    }

    [RelayCommand]
    public void OpenMainMenuWindow()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        windowsManagement.Buttons[WindowType.GenerateExport] = false;
        windowsManagement.Buttons[WindowType.MainMenu] = true;
        windowsManagement.Panels[WindowType.Generate] = false;
        windowsManagement.Panels[WindowType.Export] = false;
        windowsManagement.Panels[WindowType.MainMenu] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }
}