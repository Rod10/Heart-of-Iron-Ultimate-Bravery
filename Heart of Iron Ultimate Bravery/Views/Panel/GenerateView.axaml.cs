using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.ViewModels;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;

namespace Heart_of_Iron_Ultimate_Bravery.Views.Panel;

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
        
        Avalonia.Controls.Button button = (Avalonia.Controls.Button)sender;
        string[] parts =  button.Name.Split('_');
        // Tank tank = new Tank(Enum.Parse<TankType>(button.Name));
        // settings.CurrentMod.Countries[0].AddTank(tank);
        
        UnitType unitType = (UnitType)Enum.Parse(typeof(UnitType), parts[0]);
        if (unitType == UnitType.Ship)
        {
            
        } 
        else if (unitType == UnitType.Tank)
        {
            TankType tankType = (TankType)Enum.Parse(typeof(TankType), parts[1]);
            Tank existingTank = generateViewModel.SelectedCountry.GetTankByType(tankType);
            if (existingTank != null)
            {
                unitGenerationViewModel.UpdateView(existingTank);
            }
            else
            {
                Tank tank = new Tank(tankType);
                generateViewModel.SelectedCountry.AddTank(tank);
                unitGenerationViewModel.UpdateView(tank);
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
        unitGenerationViewModel.UpdateView();
        // Then i will redirect to the futur unit panel here
    }
}