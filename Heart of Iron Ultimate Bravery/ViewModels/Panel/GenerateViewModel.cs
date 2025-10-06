using System;
using Avalonia;
using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using Avalonia.Layout;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public class GenerateViewModel : PanelViewModelBase
{
    private bool _allCountries;
    private int _selectedCountryIndex;
    private List<string> _cbCountriesName;
    
    public ObservableCollection<ButtonItem> ButtonsRow1 { get; set; } = new();
    
    public GenerateViewModel()
    {
        CbCountriesName = new();
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        LocalizationFactory locFactory = ServiceCollectionExtensions.GetService<LocalizationFactory>();
        foreach (Country country in settings.CurrentMod.Countries)
        {
            CbCountriesName.Add(locFactory.GetString(settings.CurrentMod.Short, $"{country.Name}Text"));
        }

        UpdateView();
    }   
    
    public bool AllCountries
    {
        get { return _allCountries; }
        set { this.RaiseAndSetIfChanged(ref _allCountries, value); }
    }

    public int SelectedCountryIndex
    {
        get { return _selectedCountryIndex; }
        set { this.RaiseAndSetIfChanged(ref _selectedCountryIndex, value); }
    }

    public List<string> CbCountriesName
    {
        get { return _cbCountriesName; }
        set { this.RaiseAndSetIfChanged(ref _cbCountriesName, value); }
    }

    public void UpdateView()
    {    // Clear previous content
        ButtonsRow1.Clear();
        
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        if (windowsManagement == null) throw new SystemException("windowsManagement is null");
    
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
        Console.WriteLine("RenderShipGeneratePanel");
    }

    private void RenderTankGeneratePanel()
    {
        Settings settings =  ServiceCollectionExtensions.GetService<Settings>();
        TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(settings.CurrentMod.Short);

        int i = 0;

        foreach (TankType tankType in validTankTypes)
        {
            if (i >= 0 && i <= 2)
            {
                var modFiles = Directory.GetFiles(@$"./Assets/Mods/{settings.CurrentMod.Name}/Images", "*game-icon*");
                var modFile = modFiles[0];
                var buttonImage = ImageHelper.LoadFromResource(modFile);
                Thickness thickness = new Thickness();
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
                Console.WriteLine(thickness);
                Console.WriteLine(horizontalAlignment);
                ButtonsRow1.Add(new ButtonItem(tankType.ToString(), thickness, buttonImage, horizontalAlignment));
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