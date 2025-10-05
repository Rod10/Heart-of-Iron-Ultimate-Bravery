using System;
using Avalonia;
using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public class GenerateViewModel : PanelViewModelBase
{
    private bool _allCountries;
    private int _selectedCountryIndex;
    private List<string> _cbCountriesName;
    private UnitType _selectedUnitType;
    
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

        
        TankType[] test = EnumHelper.GetTypeArrayFromUnitType<TankType>(SelectedUnitType, settings.CurrentMod.Short);
        /*TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(settings.CurrentMod.Short);

        int i = 0;

        foreach (TankType tankType in validTankTypes)
        {
            if (i >= 0 && i <= 3)
            {
                var modFiles = Directory.GetFiles(@$"./Assets/Mods/{settings.CurrentMod.Name}/Images", "*game-icon*");
                var modFile = modFiles[0];
                var buttonImage = ImageHelper.LoadFromResource(modFile);
            }
            i++;
        }*/
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

    public UnitType SelectedUnitType
    {
        get { return _selectedUnitType; }
        set { this.RaiseAndSetIfChanged(ref _selectedUnitType, value); }
    }
}