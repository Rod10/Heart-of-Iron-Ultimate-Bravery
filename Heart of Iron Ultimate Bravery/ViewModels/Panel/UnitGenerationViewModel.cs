using System;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

public class UnitGenerationViewModel : PanelViewModelBase
{
    private UnitType unitType;

    public UnitGenerationViewModel()
    {
        UpdateView();
    }
    
    public UnitType UnitType
    {
        get { return unitType; }
        set { this.RaiseAndSetIfChanged(ref unitType, value); }
    }

    public void UpdateView()
    {
        WindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        UnitType = windowsManagement.UnitType;
    }

    public void UpdateView(Tank tank)
    {
    }
}