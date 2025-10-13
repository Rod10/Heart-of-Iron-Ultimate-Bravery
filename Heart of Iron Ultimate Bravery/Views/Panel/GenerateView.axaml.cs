using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

namespace Heart_of_Iron_Ultimate_Bravery.Views.Panel
{
  public partial class GenerateView : UserControl
  {
    public GenerateView()
    {
      InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
      MainWindowViewModel mainWindowViewModel = ServiceCollectionExtensions.GetService<MainWindowViewModel>();
      GenerateViewModel generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      UnitGenerationViewModel unitGenerationViewModel = ServiceCollectionExtensions.GetService<UnitGenerationViewModel>();
      WindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();

      windowsManagement.Buttons[WindowType.GenerateExport] = false;
      windowsManagement.Buttons[WindowType.UnitGeneration] = true;
      windowsManagement.Panels[WindowType.Generate] = false;
      windowsManagement.Panels[WindowType.UnitGeneration] = true;
      mainWindowViewModel.UpdateView();

      var button = (Avalonia.Controls.Button)sender;
      string[] parts = button.Name.Split('_');

      var unitType = (UnitType)Enum.Parse(typeof(UnitType), parts[0]);
      if (unitType == UnitType.Ship)
      {
        var shipType = (ShipType)Enum.Parse(typeof(ShipType), parts[1]);
        if (generateViewModel.AllCountries)
        {
          foreach (Country country in settings.CurrentMod.Countries)
          {
            Ship existingShip = country.GetShipByType(shipType);
            if (existingShip == null)
            {
              Ship newShip = new Ship(shipType);
              country.AddShip(newShip);
            }
          }

          Ship shipToShow = generateViewModel.SelectedCountry.GetShipByType(shipType);
          unitGenerationViewModel.UpdateView(shipToShow);
        }
        else
        {
          Ship existingShip = generateViewModel.SelectedCountry.GetShipByType(shipType);
          if (existingShip == null)
          {
            Ship newShip = new Ship(shipType);
            generateViewModel.SelectedCountry.AddShip(newShip);
            unitGenerationViewModel.UpdateView(newShip);
          }
          else
          {
            unitGenerationViewModel.UpdateView(existingShip);
          }
        }
      }
      else if (unitType == UnitType.Tank)
      {
        var tankType = (TankType)Enum.Parse(typeof(TankType), parts[1]);
        if (generateViewModel.AllCountries)
        {
          foreach (Country country in settings.CurrentMod.Countries)
          {
            Tank existingTank = country.GetTankByType(tankType);
            if (existingTank == null)
            {
              Tank tank = new Tank(tankType);
              country.AddTank(tank);
            }
          }

          Tank tankToShow = generateViewModel.SelectedCountry.GetTankByType(tankType);
          unitGenerationViewModel.UpdateView(tankToShow);
        }
        else
        {
          Tank existingTank = generateViewModel.SelectedCountry.GetTankByType(tankType);
          if (existingTank != null)
          {
            unitGenerationViewModel.UpdateView(existingTank);
          }
          else
          {
            var tank = new Tank(tankType);
            generateViewModel.SelectedCountry.AddTank(tank);
            unitGenerationViewModel.UpdateView(tank);
          }
        }
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
    }
  }
}