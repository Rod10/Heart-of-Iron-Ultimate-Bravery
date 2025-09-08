using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Heart_of_Iron_Ultimate_Bravery.ViewModels.Button;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        _currentButtonBlock = new MainMenuViewModel();
    }

    private ViewModelBase _currentButtonBlock;
    
    /// <summary>
    /// Gets the current page. The property is read-only
    /// </summary>
    public ViewModelBase CurrentButtonBlock
    {
        get { return _currentButtonBlock; }
        private set { this.RaiseAndSetIfChanged(ref _currentButtonBlock, value); }
    }
}
