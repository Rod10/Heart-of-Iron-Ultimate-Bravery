using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia.Media.Imaging;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship.Module;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Armor;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Engine;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.SpecialModule;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Suspension;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using ReactiveUI;

namespace Heart_of_Iron_Ultimate_Bravery.ViewModels.Panel
{
  public class UnitGenerationViewModel : PanelViewModelBase
  {
    private string? _unitRole;
    private UnitType _unitType;
    private Settings? _settings;
    private string? _unitName;
    private string? _modName;
    private string? _unitSubType;
    private Bitmap? _unitBackground;

    public UnitGenerationViewModel()
    {
      UpdateView();
    }

    public ObservableCollection<DesignerItem> FirstRowBackground { get; set; } = [];

    public ObservableCollection<DesignerItem> SecondRowBackground { get; set; } = [];

    public ObservableCollection<DesignerItem> SpecificDataBackground { get; set; } = [];

    public ObservableCollection<DesignerItem> FirstRowSlot { get; set; } = [];

    public ObservableCollection<DesignerItem> SecondRowSlot { get; set; } = [];

    public ObservableCollection<DesignerItem> SpecificData { get; set; } = [];

    public UnitType UnitType
    {
      get => _unitType;
      set => this.RaiseAndSetIfChanged(ref _unitType, value);
    }

    public string? UnitSubType
    {
      get => _unitSubType;
      private set => this.RaiseAndSetIfChanged(ref _unitSubType, value);
    }

    public string? UnitName
    {
      get => _unitName;
      set => this.RaiseAndSetIfChanged(ref _unitName, value);
    }

    public string? UnitRole
    {
      get => _unitRole;
      private set => this.RaiseAndSetIfChanged(ref _unitRole, value);
    }

    public Bitmap BlueprintBackground
    {
      get => _unitBackground;
      private set => this.RaiseAndSetIfChanged(ref _unitBackground, value);
    }

    public void UpdateView()
    {
      WindowsManagement? windowsManagement = ServiceCollectionExtensions.GetService<WindowsManagement>();
      UnitType = windowsManagement.UnitType;
    }

    public void UpdateView(Ship ship)
    {
      FirstRowBackground.Clear();
      SecondRowBackground.Clear();
      FirstRowSlot.Clear();
      SecondRowSlot.Clear();
      SpecificData.Clear();

      _settings = ServiceCollectionExtensions.GetService<Settings>();
      _modName = _settings.CurrentMod.Name;

      // Route to appropriate mod-specific renderer
      switch (_settings.CurrentMod.Short.ToLower())
      {
        case "vanilla":
          RenderVanillaShip(ship.GetImplementation<VanillaShip>());
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
          // RenderVanillaTank(tank.GetImplementation<VanillaTank>()); // Fallback
          break;
      }
    }

    public void UpdateView(Tank tank)
    {
      FirstRowBackground.Clear();
      SecondRowBackground.Clear();
      FirstRowSlot.Clear();
      SecondRowSlot.Clear();
      SpecificData.Clear();

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
      string[] modFiles = Directory.GetFiles(@$"./Assets/Mods/{_modName}/Images/Units/Tank/Modules/{module}", $"*{moduleName}*");
      string modFile = modFiles[0];
      return ImageHelper.LoadFromResource(modFile);
    }

    /* Vanilla Part */

    private void RenderVanillaShip(VanillaShip ship)
    {
      UnitSubType = ship.Type.ToString();
      RenderVanillaShipBackground();
      UnitName = ship.Name;
      UnitRole = ship.Type.ToString();

      double[] left = [12, 80, 140, 203, 264, 327];
      int i = 0;
      foreach (KeyValuePair<VanillaModule.ModuleType, VanillaModule?> module in ship.CustomModule)
      {
        string slotName = module.Key.ToString();
        string moduleName = $"{}";

        // Bitmap image = GetModuleImage(slotName, moduleName);

        // FirstRowBackground.Add(new DesignerItem(image, left[i], 231, 56));
        i++;
      }
    }

    private void RenderVanillaTank(VanillaTank tank)
    {
      UnitSubType = tank.Type.ToString();
      RenderVanillaTankBackground();
      UnitName = tank.Name;
      UnitRole = tank.Role.ToString();

      /* Turret Slot */
      VanillaTurret turret = tank.Turret.GetImplementation<VanillaTurret>();
      string moduleName = $"{turret.Type.ToString().ToLower()}_turret_{turret.Crew}";
      Bitmap image = GetModuleImage("Turret", moduleName);
      FirstRowSlot.Add(new DesignerItem(image, 12, 231, 56));
      /* /Turret Slot */

      /* Canon Slot */
      VanillaCannon cannon = tank.Cannon.GetImplementation<VanillaCannon>();
      moduleName = $"{cannon.SubType.ToString().FirstCharToLower()}_{cannon.Version.ToString().ToLower()}";
      image = GetModuleImage("Cannon", moduleName);
      FirstRowSlot.Add(new DesignerItem(image, 80, 230, 56));
      /* /Canon Slot */

      /* Special Module Slot */
      double[] left = [140, 203, 264, 327];
      int i = 0;
      foreach (VanillaSpecialModule module in tank.SpecialModules.Select(specialModule => specialModule.GetImplementation<VanillaSpecialModule>()))
      {
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
      SecondRowSlot.Add(new DesignerItem(image, 11, 485, 56));
      /* Suspension Slot */

      /* Armor Slot */
      VanillaArmor armor = tank.Armor.GetImplementation<VanillaArmor>();
      moduleName = $"{armor.Type.ToString().FirstCharToLower()}";
      image = GetModuleImage("Armor", moduleName);
      SecondRowSlot.Add(new DesignerItem(image, 74, 485, 56));
      /* /Armor Slot */

      /* Engine Slot */
      VanillaEngine engine = tank.Engine.GetImplementation<VanillaEngine>();
      moduleName = $"{engine.Type.ToString().FirstCharToLower()}";
      image = GetModuleImage("Engine", moduleName);
      SecondRowSlot.Add(new DesignerItem(image, 137, 485, 56));
      /* /Engine Slot */

      SpecificData.Add(new DesignerItem(null, 315, 500, null, tank.EngineLevel.ToString()));
      SpecificData.Add(new DesignerItem(null, 395, 500, null, tank.ArmorLevel.ToString()));
    }

    private void RenderVanillaShipBackground()
    {
      string[] modFiles = Directory.GetFiles(@$"./Assets/Mods/{_settings.CurrentMod.Name}/Images/", "*equipment_icon_bg*");
      string modFile = modFiles[0];
      Bitmap imageSlot = ImageHelper.LoadFromResource(modFile);

      FirstRowBackground.Add(new DesignerItem(imageSlot, 13, 231, 65));
      FirstRowBackground.Add(new DesignerItem(imageSlot, 76, 231, 65));
      FirstRowBackground.Add(new DesignerItem(imageSlot, 139, 231, 65));
      FirstRowBackground.Add(new DesignerItem(imageSlot, 202, 231, 65));
      FirstRowBackground.Add(new DesignerItem(imageSlot, 264, 231, 65));
      FirstRowBackground.Add(new DesignerItem(imageSlot, 327, 231, 65));
      FirstRowBackground.Add(new DesignerItem(imageSlot, 390, 231, 65));

      SecondRowBackground.Add(new DesignerItem(imageSlot, 13, 485, 65));
      SecondRowBackground.Add(new DesignerItem(imageSlot, 76, 485, 65));
      SecondRowBackground.Add(new DesignerItem(imageSlot, 139, 485, 65));
      SecondRowBackground.Add(new DesignerItem(imageSlot, 202, 485, 65));
      SecondRowBackground.Add(new DesignerItem(imageSlot, 264, 485, 65));
      SecondRowBackground.Add(new DesignerItem(imageSlot, 327, 485, 65));
      SecondRowBackground.Add(new DesignerItem(imageSlot, 390, 485, 65));

      modFiles = Directory.GetFiles(@$"./Assets/Mods/{_settings.CurrentMod.Name}/Images/Units/Ship/", "*ship_view_bg*");
      modFile = modFiles[0];
      BlueprintBackground = ImageHelper.LoadFromResource(modFile);
    }

    private void RenderVanillaTankBackground()
    {
      string[] modFiles = Directory.GetFiles(@$"./Assets/Mods/{_settings.CurrentMod.Name}/Images", "*equipment_icon_bg*");
      string modFile = modFiles[0];
      Bitmap imageSlot = ImageHelper.LoadFromResource(modFile);

      FirstRowBackground.Add(new DesignerItem(imageSlot, 13, 231, 65));  // Turret Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 76, 231, 65));  // Canon Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 139, 231, 65)); // Special Module Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 202, 231, 65)); // Special Module Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 264, 231, 65)); // Special Module Slot
      FirstRowBackground.Add(new DesignerItem(imageSlot, 327, 231, 65)); // Special Module Slot

      SecondRowBackground.Add(new DesignerItem(imageSlot, 13, 485, 65));  // Suspension Slot
      SecondRowBackground.Add(new DesignerItem(imageSlot, 76, 485, 65));  // Armor Slot
      SecondRowBackground.Add(new DesignerItem(imageSlot, 139, 485, 65)); // Engine Module Slot

      SpecificDataBackground.Add(new DesignerItem(null, 300, 485, null, Assets.Localization.Resources.ResourceManager.GetString($"EngineText")));
      SpecificDataBackground.Add(new DesignerItem(null, 380, 485, null, Assets.Localization.Resources.ResourceManager.GetString($"ArmorText")));

      modFiles = Directory.GetFiles(@$"./Assets/Mods/{_settings.CurrentMod.Name}/Images/Units/Tank", "*tank_blueprint_bg*");
      modFile = modFiles[0];
      BlueprintBackground = ImageHelper.LoadFromResource(modFile);
    }

    /* /Vanilla Part */
  }
}