using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Media.Imaging;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.SpecialModule;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Suspension;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel
{
  public class UnitGenerationViewModel : PanelViewModelBase
  {
    private string _unitRole;
    private UnitType _unitType;
    private Settings? _settings;
    private string _unitName;
    private string _modName;
    private string _unitSubType;

    public UnitGenerationViewModel()
    {
      UpdateView();
    }

    public ObservableCollection<DesignerItem> FirstRowBackground { get; set; } = [];
    public ObservableCollection<DesignerItem> SecondRowBackground { get; set; } = [];
    public ObservableCollection<DesignerItem> FirstRowSlot { get; set; } = [];

    public UnitType UnitType
    {
      get => _unitType;
      set => this.RaiseAndSetIfChanged(ref _unitType, value);
    }

    public string UnitSubType
    {
      get => _unitSubType;
      private set => this.RaiseAndSetIfChanged(ref _unitSubType, value);
    }

    public string UnitName
    {
      get => _unitName;
      set => this.RaiseAndSetIfChanged(ref _unitName, value);
    }

    public string UnitRole
    {
      get => _unitRole;
      private set => this.RaiseAndSetIfChanged(ref _unitRole, value);
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
      FirstRowSlot.Clear();

      _settings = ServiceCollectionExtensions.GetService<Settings>();
      _modName = _settings.CurrentMod.Name;

      // Route to appropriate mod-specific renderer
      switch (_settings.CurrentMod.Short.ToLower())
      {
        case "vanilla":
          RenderVanillaTank(tank.GetImplementation<VanillaTank>());
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
          RenderVanillaTank(tank.GetImplementation<VanillaTank>()); // Fallback
          break;
      }
    }

    private Bitmap GetModuleImage(string module, string moduleName)
    {
      string[]? modFiles = Directory.GetFiles(@$"./Assets/Mods/{_modName}/Images/Units/Tank/Modules/{module}", $"*{moduleName}*");
      string? modFile = modFiles[0];
      return ImageHelper.LoadFromResource(modFile);
    }

    /* Vanilla Part */
    private void RenderVanillaTank(VanillaTank tank)
    {
      UnitSubType = tank.Type.ToString();
      RenderVanillaBackground();
      UnitName = tank.Name;
      UnitRole = tank.Role.ToString();
      Bitmap? image;

      /* Turret Slot */
      VanillaTurret turret = tank.Turret.GetImplementation<VanillaTurret>();
      string moduleName = $"{turret.Type.ToString().ToLower()}_turret_{turret.Crew}";
      image = GetModuleImage("Turret", moduleName);
      FirstRowSlot.Add(new DesignerItem(image, 12, 231, 56));
      /* /Turret Slot */

      /* Canon Slot */
      VanillaCannon cannon = tank.Cannon.GetImplementation<VanillaCannon>();
      moduleName = $"{cannon.SubType.ToString().FirstCharToLower()}_{cannon.Version.ToString().ToLower()}";
      image = GetModuleImage("Cannon", moduleName);
      FirstRowSlot.Add(new DesignerItem(image, 80, 230, 56));
      /* /Canon Slot */

      double[] left = [140, 203, 264, 327];

      /* Special Module Slot */
      int i = 0;
      foreach (SpecialModule specialModule in tank.SpecialModules)
      {
        VanillaSpecialModule module = specialModule.GetImplementation<VanillaSpecialModule>();
        moduleName = $"{module.Type.ToString().FirstCharToLower()}";
        image = GetModuleImage("Special", moduleName);
        FirstRowSlot.Add(new DesignerItem(image, left[i], 230, 56));
        i++;
      }

      /* /Special Module Slot */

      /* Suspension Slot */
      VanillaSuspension suspension = tank.Suspension.GetImplementation<VanillaSuspension>();
      moduleName = $"{suspension.Type.ToString().FirstCharToLower()}";
      image = GetModuleImage("Suspension", moduleName);
      FirstRowSlot.Add(new DesignerItem(image, 11, 485, 56));
      /* Suspension Slot */
    }

    private void RenderVanillaBackground()
    {
      var modFiles = Directory.GetFiles(@$"./Assets/Mods/{_settings.CurrentMod.Name}/Images/", "*equipment_icon_bg*");
      var modFile = modFiles[0];
      var imageSlot = ImageHelper.LoadFromResource(modFile);

      FirstRowBackground.Add(new DesignerItem(imageSlot, 13, 231, 65)); // Turret Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 76, 231, 65)); // Canon Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 139, 231, 65)); // Special Module Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 202, 231, 65)); // Special Module Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 264, 231, 65)); // Special Module Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 327, 231, 65)); // Special Module Slot

      SecondRowBackground.Add(new DesignerItem(imageSlot, 13, 485, 65));  // Suspension Slot
      SecondRowBackground.Add(new DesignerItem(imageSlot, 76, 485, 65));  // Armor Slot
      SecondRowBackground.Add(new DesignerItem(imageSlot, 139, 485, 65)); // Engine Module Slot
    }

    /* /Vanilla Part */
  }
}