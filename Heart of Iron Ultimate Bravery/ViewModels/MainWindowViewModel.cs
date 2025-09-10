using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        SetNewButtonBlock();
    }

    public Guid Id { get; } = Guid.NewGuid();
    private ButtonBlockViewModelBase? _currentButtonBlock;
    
    /// <summary>
    /// Gets the current page. The property is read-only
    /// </summary>
    public ButtonBlockViewModelBase? CurrentButtonBlock
    {
        get { return _currentButtonBlock; }
        private set { this.RaiseAndSetIfChanged(ref _currentButtonBlock, value); }
    }

    public void SetNewButtonBlock()
    {
        Console.WriteLine($@"SetNewButtonBlock: {Id}");
        IWindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<IWindowsManagement>();
        if (windowsManagement == null) throw new SystemException("windowsManagement is null");
        if (windowsManagement.Buttons[WindowType.MainMenu])
        {
            //_currentButtonBlock = new MainMenuViewModel();
            CurrentButtonBlock = new MainMenuViewModel();
        } 
        else if (windowsManagement.Buttons[WindowType.GenerateExport])
        {
            //_currentButtonBlock = new GenerateExportViewModel();
            CurrentButtonBlock = new GenerateExportViewModel();
        } 
        else if (windowsManagement.Buttons[WindowType.Multiplayer])
        {
            Console.WriteLine("Multiplayer button");
        } 
        else if (windowsManagement.Buttons[WindowType.Settings])
        {
            Console.WriteLine("Settings button");
        }
    }
}
