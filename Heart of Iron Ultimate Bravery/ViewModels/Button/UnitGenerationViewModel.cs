using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;

public partial class UnitGenerationViewModel : ButtonBlockViewModelBase
{
    
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