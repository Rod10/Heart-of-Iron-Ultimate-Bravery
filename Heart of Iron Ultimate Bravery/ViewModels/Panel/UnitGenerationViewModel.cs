using System.Collections.ObjectModel;
using System.IO;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel
{
  public class UnitGenerationViewModel : PanelViewModelBase
  {
    // ReSharper disable once InconsistentNaming
    private UnitType _unitType;
    private Tank? _currentTank;
    private Settings? _settings;

    public UnitGenerationViewModel()
    {
      UpdateView();
    }

    public ObservableCollection<DesignerItem> FirstRowBackground { get; set; } = [];
    public ObservableCollection<DesignerItem> SecondRowBackground { get; set; } = [];

    public UnitType UnitType
    {
      get => _unitType;
      set => this.RaiseAndSetIfChanged(ref _unitType, value);
    }

    public void UpdateView()
    {
      WindowsManagement windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
      UnitType = windowsManagement.UnitType;
    }

    public void UpdateView(Tank tank)
    {
      FirstRowBackground.Clear();
      SecondRowBackground.Clear();
      _currentTank = tank;

      _settings = ServiceCollectionExtensions.GetService<Settings>();

      // Route to appropriate mod-specific renderer
      switch (_settings.CurrentMod.Short.ToLower())
      {
        case "vanilla":
          RenderVanillaTank();
          break;
        /*case "kaiserreich":
            RenderKaiserreichTank(tank);
            break;
        case "road56":
            RenderRoad56Tank(tank);
            break;
        case "millenniumdawn":
            RenderMillenniumDawnTank(tank);
            break;*/
        default:
          RenderVanillaTank(); // Fallback
          break;
      }
    }

    /* Vanilla Part */
    private void RenderVanillaTank()
    {
      RenderVanillaBackground();
    }

    private void RenderVanillaBackground()
    {
      var modFiles = Directory.GetFiles(@$"./Assets/Mods/{_settings.CurrentMod.Name}/Images/", "*equipment_icon_bg*");
      var modFile = modFiles[0];
      var imageSlot = ImageHelper.LoadFromResource(modFile);

      // Turret Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 13, 231, 65));
    }

    /* /Vanilla Part */
  }
}