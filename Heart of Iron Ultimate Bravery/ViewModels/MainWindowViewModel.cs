using System;
using System.IO;
using System.Threading.Tasks;
using AvaloniaDialogs.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using MultiplayerViewModel = Heart_of_Iron_Ultimate_Bravery.ViewModels.Button.MultiplayerViewModel;
using SettingsViewModel = Heart_of_Iron_Ultimate_Bravery.ViewModels.Button.SettingsViewModel;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        UpdateView();
    }
    
    private ButtonBlockViewModelBase? _currentButtonBlock;
    private PanelViewModelBase? _currentPanel;
    
    /// <summary>
    /// Gets the current page. The property is read-only
    /// </summary>
    public ButtonBlockViewModelBase? CurrentButtonBlock
    {
        get { return _currentButtonBlock; }
        private set { this.RaiseAndSetIfChanged(ref _currentButtonBlock, value); }
    }
    
    /// <summary>
    /// Gets the current page. The property is read-only
    /// </summary>
    public PanelViewModelBase? CurrentPanel
    {
        get { return _currentPanel; }
        private set { this.RaiseAndSetIfChanged(ref _currentPanel, value); }
    }

    public void UpdateView()
    {
        SetNewButtonBlock();
        SetNewPanel();
    }
    
    private void SetNewButtonBlock()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        if (windowsManagement == null) throw new SystemException("windowsManagement is null");
        if (windowsManagement.Buttons[WindowType.MainMenu])
        {
            CurrentButtonBlock = new Button.MainMenuViewModel();
        } 
        else if (windowsManagement.Buttons[WindowType.GenerateExport])
        {
            CurrentButtonBlock = new GenerateExportViewModel();
        } 
        else if (windowsManagement.Buttons[WindowType.Multiplayer])
        {
            CurrentButtonBlock = new MultiplayerViewModel();
        } 
        else if (windowsManagement.Buttons[WindowType.Settings])
        {
            CurrentButtonBlock = new SettingsViewModel();
        }
    }

    private void SetNewPanel()
    {
        WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
        GenerateViewModel? generateViewModel = ServiceCollectionExtensions.GetService<GenerateViewModel>();
        if (windowsManagement == null) throw new SystemException("windowsManagement is null");
        if (windowsManagement.Panels[WindowType.MainMenu])
        {
            CurrentPanel = new Panel.MainMenuViewModel();
        } 
        else if (windowsManagement.Panels[WindowType.Generate])
        {
            CurrentPanel = generateViewModel;
        }
        else if (windowsManagement.Panels[WindowType.Export])
        {
            CurrentPanel = new Panel.ExportViewModel();
        }
        else if (windowsManagement.Panels[WindowType.Multiplayer])
        {
            CurrentPanel = new Panel.MultiplayerViewModel();
        }
        else if (windowsManagement.Panels[WindowType.Settings])
        {
            CurrentPanel = new Panel.SettingsViewModel();
        }
    }

    public async void openDialogBox(string modPath)
    {
        string message;
        if (Directory.Exists(modPath))
        {
            message = "Mod found";
        }
        else
        {
            message = "Mod not found";
        }
        SingleActionDialog dialog = new() {
            Message = message,
            ButtonText = "Okay"
        };
        if ((await dialog.ShowAsync()).HasValue)
        {
        }
    }
}
