using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class GenerateExportViewModel : ButtonBlockViewModelBase
{
    
    [RelayCommand]
    public void OpenShipWindow()
    {}
    
    [RelayCommand]
    public void OpenTankWindow()
    {
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!;
        Random rnd = new Random();
        TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(settings.CurrentMod.Short);
        TankType tankType = validTankTypes[rnd.Next(0, validTankTypes.Length)];
        Console.WriteLine("/** Tank **/");
        Tank tank = new Tank(tankType);
        Console.WriteLine("/** Tank **/");
    }
    
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
        windowsManagement.Panels[WindowType.Generate] = false;
        windowsManagement.Panels[WindowType.Export] = false;
        windowsManagement.Panels[WindowType.MainMenu] = true;
        MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
        mainWindowViewModel.UpdateView();
    }
}