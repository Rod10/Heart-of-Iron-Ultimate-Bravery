using System;
using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public class GenerateViewModel : PanelViewModelBase
{
    private bool _allCountries;
    private int _selectedCountryIndex;
    private List<string> _cbCountriesName;
    
    public GenerateViewModel()
    {
        CbCountriesName = new();
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        LocalizationFactory locFactory = ServiceCollectionExtensions.GetService<LocalizationFactory>();
        foreach (Country country in settings.CurrentMod.Countries)
        {
            CbCountriesName.Add(locFactory.GetString(settings.CurrentMod.Short, $"{country.Name}Text"));
        }
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
}