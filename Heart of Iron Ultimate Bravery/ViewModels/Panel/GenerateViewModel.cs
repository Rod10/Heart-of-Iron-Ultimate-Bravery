using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Avalonia;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel
{
  public class GenerateViewModel : PanelViewModelBase
  {
    private bool _allCountries;
    private int _selectedCountryIndex;
    private Country _selectedCountry;
    private List<string> _cbCountriesName;

    public ObservableCollection<ButtonItem> ButtonsRow1 { get; set; } = new ObservableCollection<ButtonItem>();
    public ObservableCollection<ButtonItem> ButtonsRow2 { get; set; } = new ObservableCollection<ButtonItem>();

    public GenerateViewModel()
    {
      CbCountriesName = new List<string>();
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      LocalizationFactory locFactory = ServiceCollectionExtensions.GetService<LocalizationFactory>();
      foreach (Country country in settings.CurrentMod.Countries)
      {
        CbCountriesName.Add(locFactory.GetString(settings.CurrentMod.Short, $"{country.Name}Text"));
      }

      SelectedCountryIndex = 0;
      UpdateView();
    }

    public bool AllCountries
    {
      get => _allCountries;
      set => this.RaiseAndSetIfChanged(ref _allCountries, value);
    }

    public int SelectedCountryIndex
    {
      get => _selectedCountryIndex;
      set
      {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        this.RaiseAndSetIfChanged(ref _selectedCountryIndex, value);
        SelectedCountry = settings.CurrentMod.Countries[_selectedCountryIndex];
      }
    }

    public Country SelectedCountry
    {
      get => _selectedCountry;
      set => this.RaiseAndSetIfChanged(ref _selectedCountry, value);
    }

    public List<string> CbCountriesName
    {
      get => _cbCountriesName;
      set => this.RaiseAndSetIfChanged(ref _cbCountriesName, value);
    }

    public void UpdateView()
    { // Clear previous content
      ButtonsRow1.Clear();
      ButtonsRow2.Clear();

      WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
      if (windowsManagement == null)
      {
        throw new SystemException("windowsManagement is null");
      }

      // Render appropriate panel based on selected unit type
      switch (windowsManagement.UnitType)
      {
        case UnitType.Ship:
          RenderShipGeneratePanel();
          break;
        case UnitType.Tank:
          RenderTankGeneratePanel();
          break;
        case UnitType.Plane:
          RenderPlaneGeneratePanel();
          break;
        case UnitType.Division:
          RenderDivisionGeneratePanel();
          break;
        case UnitType.Doctrine:
          RenderDoctrineGeneratePanel();
          break;
        default:
          RenderTankGeneratePanel(); // Default fallback
          break;
      }
    }

    private void RenderShipGeneratePanel()
    {
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      ShipType[] validShipTypes = EnumHelper.GetEnumTypeArrayForMod<ShipType>(settings.CurrentMod.Short);

      int i = 0;

      foreach (ShipType shipType in validShipTypes)
      {
        string[] modFiles = Directory.GetFiles(@$"./Assets/Mods/{settings.CurrentMod.Name}/Images/Units/Ship/Type", $"*{shipType.ToString()}*");
        string modFile = modFiles[0];
        Bitmap buttonImage = ImageHelper.LoadFromResource(modFile);
        string name = $"Ship_{shipType.ToString()}";
        if (i >= 0 && i <= 2)
        {
          var thickness = default(Thickness);
          HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
          switch (i)
          {
            case 0:
              {
                thickness = new Thickness(56, 0, 0, 0);
                break;
              }

            case 1:
              {
                thickness = new Thickness(0, 0, 0, 0);
                horizontalAlignment = HorizontalAlignment.Center;
                break;
              }

            case 2:
              {
                thickness = new Thickness(0, 0, 56, 0);
                horizontalAlignment = HorizontalAlignment.Right;
                break;
              }
          }

          ButtonsRow1.Add(new ButtonItem(name, thickness, buttonImage, horizontalAlignment));
        }
        else
        {
          var thickness = default(Thickness);
          HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
          switch (i)
          {
            case 3:
              {
                thickness = new Thickness(56, 0, 0, 0);
                break;
              }

            case 4:
              {
                thickness = new Thickness(0, 0, 0, 0);
                horizontalAlignment = HorizontalAlignment.Center;
                break;
              }

            case 5:
              {
                thickness = new Thickness(0, 0, 56, 0);
                horizontalAlignment = HorizontalAlignment.Right;
                break;
              }
          }

          ButtonsRow2.Add(new ButtonItem(name, thickness, buttonImage, horizontalAlignment));
        }

        i++;
      }
    }

    private void RenderTankGeneratePanel()
    {
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(settings.CurrentMod.Short);

      int i = 0;

      foreach (TankType tankType in validTankTypes)
      {
        string name = $"Tank_{tankType.ToString()}";
        string[] modFiles = Directory.GetFiles(@$"./Assets/Mods/{settings.CurrentMod.Name}/Images/Units/Tank/Type", $"*{tankType.ToString()}*");
        string modFile = modFiles[0];
        Bitmap buttonImage = ImageHelper.LoadFromResource(modFile);
        if (i >= 0 && i <= 2)
        {
          var thickness = default(Thickness);
          HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
          switch (i)
          {
            case 0:
              {
                thickness = new Thickness(56, 0, 0, 0);
                break;
              }

            case 1:
              {
                thickness = new Thickness(0, 0, 0, 0);
                horizontalAlignment = HorizontalAlignment.Center;
                break;
              }

            case 2:
              {
                thickness = new Thickness(0, 0, 56, 0);
                horizontalAlignment = HorizontalAlignment.Right;
                break;
              }
          }

          ButtonsRow1.Add(new ButtonItem(name, thickness, buttonImage, horizontalAlignment));
        }
        else
        {
          var thickness = default(Thickness);
          HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
          switch (i)
          {
            case 3:
              {
                thickness = new Thickness(56, 0, 0, 0);
                break;
              }

            case 4:
              {
                thickness = new Thickness(0, 0, 0, 0);
                horizontalAlignment = HorizontalAlignment.Center;
                break;
              }

            case 5:
              {
                thickness = new Thickness(0, 0, 56, 0);
                horizontalAlignment = HorizontalAlignment.Right;
                break;
              }
          }

          ButtonsRow2.Add(new ButtonItem(name, thickness, buttonImage, horizontalAlignment));
        }

        i++;
      }
    }

    private void RenderPlaneGeneratePanel()
    {
      Console.WriteLine("RenderPlaneGeneratePanel");
    }

    private void RenderDivisionGeneratePanel()
    {
      Console.WriteLine("RenderDivisionGeneratePanel");
    }

    private void RenderDoctrineGeneratePanel()
    {
      Console.WriteLine("RenderDoctrineGeneratePanel");
    }
  }
}