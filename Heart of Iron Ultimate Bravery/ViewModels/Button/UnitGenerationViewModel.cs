using System;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button
{
  public partial class UnitGenerationViewModel : ButtonBlockViewModelBase
  {

    [RelayCommand]
    public void Regenerate()
    {
      MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>();
      GenerateViewModel generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      Panel.UnitGenerationViewModel unitGenerationViewModel = ServiceCollectionExtensions.GetService<Panel.UnitGenerationViewModel>();
      WindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();

      UnitType unitType = unitGenerationViewModel.UnitType;

      if (unitType == UnitType.Ship)
      {

      }
      else if (unitType == UnitType.Tank)
      {
        TankType tankType = Enum.Parse<TankType>(unitGenerationViewModel.UnitSubType);
        Tank tank = new Tank(tankType);
        generateViewModel.SelectedCountry.AddTank(tank);
        unitGenerationViewModel.UpdateView(tank);
      }
      else if (unitType == UnitType.Plane)
      {
      }
      else if (unitType == UnitType.Division)
      {

      }
      else if (unitType == UnitType.Doctrine)
      {

      }
      unitGenerationViewModel.UpdateView();
    }

    [RelayCommand]
    public void OpenGenerationWindow()
    {
      WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
      windowsManagement.Buttons[WindowType.UnitGeneration] = false;
      windowsManagement.Buttons[WindowType.GenerateExport] = true;
      windowsManagement.Panels[WindowType.UnitGeneration] = false;
      windowsManagement.Panels[WindowType.Generate] = true;
      MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>()!;
      mainWindowViewModel.UpdateView();
    }
  }
}