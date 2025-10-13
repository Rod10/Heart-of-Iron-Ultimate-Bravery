using System;
using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship.Module
{
  public class VanillaModule : BaseModule
  {
    public ModuleType Type;
    public ModuleSubType? SubType;
    public ModuleVersion Version;

    public enum ModuleType
    {
      Aircraft,
      AntiAir,
      AntiSubmarine,
      Armor,
      Engine,
      FireControl,
      Fuel,
      HeavyBattery,
      LightBattery,
      Mine,
      Radar,
      Secondary,
      Snorkel,
      Sonar,
      Torpedo,
      None
    }

    public enum ModuleSubType
    {
      Light,
      LightCruiser,
      DualPurpose,
      AutoLoader,
      MineLaying,
      MineSweeping,
      Secondary,
    }

    public enum ModuleVersion
    {
      Early,
      Basic,
      Improved,
      Advanced,
      SuperHeavyBattleship,
    }

    public static Dictionary<ModuleType, VanillaModule?> GetFixedModule(ShipType type, ShipVersion version, VanillaShip.ShipSubType? subType)
    {
      return type switch
      {
        ShipType.Destroyer => new Dictionary<ModuleType, VanillaModule?>
        {
          { ModuleType.LightBattery, new VanillaModule().CreateModule(ModuleType.LightBattery) },
          { ModuleType.AntiAir, new VanillaModule().CreateModule(ModuleType.AntiAir) },
          { ModuleType.FireControl, new VanillaModule().CreateModule(ModuleType.FireControl) },
          { ModuleType.Sonar, new VanillaModule().CreateModule(ModuleType.Sonar) },
          { ModuleType.Torpedo, new VanillaModule().CreateModule(ModuleType.Torpedo) },
          { ModuleType.Engine, new VanillaModule().CreateModule(ModuleType.Engine) },
          { ModuleType.None, null },
        },
        ShipType.Cruiser => subType switch
        {
          VanillaShip.ShipSubType.LightCruiser => new Dictionary<ModuleType, VanillaModule?>
          {
            { ModuleType.LightBattery, new VanillaModule().CreateModule(ModuleType.LightBattery) },
            { ModuleType.AntiAir, new VanillaModule().CreateModule(ModuleType.AntiAir) },
            { ModuleType.FireControl, new VanillaModule().CreateModule(ModuleType.FireControl) },
            { ModuleType.Sonar, new VanillaModule().CreateModule(ModuleType.Sonar) },
            { ModuleType.Torpedo, new VanillaModule().CreateModule(ModuleType.Torpedo) },
            { ModuleType.Engine, new VanillaModule().CreateModule(ModuleType.Engine) },
            { ModuleType.None, null },
          },
          VanillaShip.ShipSubType.HeavyCruiser => new Dictionary<ModuleType, VanillaModule?>
          {
            { ModuleType.HeavyBattery, new VanillaModule().CreateModule(ModuleType.HeavyBattery, VanillaShip.ShipSubType.HeavyCruiser) },
            { ModuleType.AntiAir, new VanillaModule().CreateModule(ModuleType.AntiAir) },
            { ModuleType.FireControl, new VanillaModule().CreateModule(ModuleType.FireControl) },
            { ModuleType.Sonar, new VanillaModule().CreateModule(ModuleType.Sonar) },
            { ModuleType.Torpedo, new VanillaModule().CreateModule(ModuleType.Torpedo) },
            { ModuleType.Engine, new VanillaModule().CreateModule(ModuleType.Engine) },
            { ModuleType.None, null },
          },
          _ => throw new ArgumentException("Invalid ShipSubType"),
        },
        ShipType.Battleship => subType switch
        {
          VanillaShip.ShipSubType.Battlecruiser => new Dictionary<ModuleType, VanillaModule?>
          {
            { ModuleType.HeavyBattery, new VanillaModule().CreateModule(ModuleType.HeavyBattery, VanillaShip.ShipSubType.Battlecruiser) },
            { ModuleType.AntiAir, new VanillaModule().CreateModule(ModuleType.AntiAir) },
            { ModuleType.FireControl, new VanillaModule().CreateModule(ModuleType.FireControl) },
            { ModuleType.Radar, new VanillaModule().CreateModule(ModuleType.Radar) },
            { ModuleType.Torpedo, new VanillaModule().CreateModule(ModuleType.Torpedo) },
            { ModuleType.Engine, new VanillaModule().CreateModule(ModuleType.Engine) },
            { ModuleType.Armor, new VanillaModule().CreateModule(ModuleType.Armor, VanillaShip.ShipSubType.Battlecruiser) },
          },
          VanillaShip.ShipSubType.Battleship => new Dictionary<ModuleType, VanillaModule?>
          {
            { ModuleType.HeavyBattery, new VanillaModule().CreateModule(ModuleType.HeavyBattery, VanillaShip.ShipSubType.Battleship) },
            { ModuleType.AntiAir, new VanillaModule().CreateModule(ModuleType.AntiAir) },
            { ModuleType.FireControl, new VanillaModule().CreateModule(ModuleType.FireControl) },
            { ModuleType.Radar, new VanillaModule().CreateModule(ModuleType.Radar) },
            { ModuleType.Torpedo, new VanillaModule().CreateModule(ModuleType.Torpedo) },
            { ModuleType.Engine, new VanillaModule().CreateModule(ModuleType.Engine) },
            { ModuleType.Armor, new VanillaModule().CreateModule(ModuleType.Armor, VanillaShip.ShipSubType.Battleship) },
          },
          VanillaShip.ShipSubType.SuperHeavyBattleship => new Dictionary<ModuleType, VanillaModule?>
          {
            { ModuleType.HeavyBattery, new VanillaModule().CreateModule(ModuleType.HeavyBattery, VanillaShip.ShipSubType.SuperHeavyBattleship) },
            { ModuleType.AntiAir, new VanillaModule().CreateModule(ModuleType.AntiAir) },
            { ModuleType.FireControl, new VanillaModule().CreateModule(ModuleType.FireControl) },
            { ModuleType.Radar, new VanillaModule().CreateModule(ModuleType.Radar) },
            { ModuleType.Torpedo, new VanillaModule().CreateModule(ModuleType.Torpedo) },
            { ModuleType.Engine, new VanillaModule().CreateModule(ModuleType.Engine) },
            { ModuleType.Armor, new VanillaModule().CreateModule(ModuleType.Armor) },
          },
          _ => throw new ArgumentException("Invalid ShipSubType"),
        },
        ShipType.Carrier => new Dictionary<ModuleType, VanillaModule?>
        {
          { ModuleType.Aircraft, new VanillaModule().CreateModule(ModuleType.Aircraft) },
          { ModuleType.Aircraft, new VanillaModule().CreateModule(ModuleType.Aircraft) },
          { ModuleType.AntiAir, new VanillaModule().CreateModule(ModuleType.AntiAir) },
          { ModuleType.Radar, new VanillaModule().CreateModule(ModuleType.Radar) },
          { ModuleType.Engine, new VanillaModule().CreateModule(ModuleType.Engine) },
          { ModuleType.Secondary, new VanillaModule().CreateModule(ModuleType.Secondary) },
          { ModuleType.Armor, new VanillaModule().CreateModule(ModuleType.Armor) },
        },
        _ => throw new ArgumentException("Invalid ShipType"),
      };
    }

    public static Dictionary<ModuleType, VanillaModule?> GetCustomsModule(ShipType type,
      VanillaShip.ShipSubType? subType, ShipVersion version)
    {
      return type switch
      {
        ShipType.Destroyer => GetDestroyerCustomsModules(version),
        ShipType.Cruiser => GetCruiserCustomsModules(subType, version),
        _ => throw new ArgumentException("Invalid ShipType"),
      };
    }

    public VanillaModule CreateModule(ModuleType type)
    {
      Type = type;
      return this;
    }

    public VanillaModule CreateModule(ModuleType type, VanillaShip.ShipSubType subType)
    {
      Type = type;
      return this;
    }

    public override void InitializeModSpecificProperties()
    {
      // Initialize vanilla-specific defaults
      // specialModule = new List<SpecialModule>();
      // engineLevel = 1;
      // armorLevel = 1;
    }

    public override string GetModIdentifier()
    {
      return "vanilla";
    }

    private static Dictionary<ModuleType, VanillaModule?> GetDestroyerCustomsModules(ShipVersion version)
    {
      var rnd = new Random();
      Dictionary<ModuleType, VanillaModule?> customModules = new();
      var customModulesSlot = new ModuleType[][] { };
      switch (version)
      {
        case ShipVersion.Early:
          {
            customModulesSlot[0] = [ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine];
            customModulesSlot[1] = [ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine];
            customModulesSlot[2] = [ModuleType.None];
            customModulesSlot[3] = [ModuleType.None];
            customModulesSlot[4] = [ModuleType.None];
            customModulesSlot[5] = [ModuleType.None];
            customModulesSlot[6] = [ModuleType.None];
            break;
          }

        case ShipVersion.Basic:
          {
            customModulesSlot[0] =
            [
              ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine
            ];
            customModulesSlot[1] =
            [
              ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine
            ];
            customModulesSlot[2] = [ModuleType.None];
            customModulesSlot[3] = [ModuleType.None];
            customModulesSlot[4] = [ModuleType.None];
            customModulesSlot[5] = [ModuleType.None];
            customModulesSlot[6] = [ModuleType.None];
            break;
          }

        case ShipVersion.Improved:
          {
            customModulesSlot[0] = [ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.AntiSubmarine];
            customModulesSlot[1] =
            [
              ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine
            ];
            customModulesSlot[2] =
            [
              ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine
            ];
            customModulesSlot[3] = [ModuleType.None];
            customModulesSlot[4] = [ModuleType.None];
            customModulesSlot[5] = [ModuleType.None];
            customModulesSlot[6] = [ModuleType.None];
            break;
          }

        case ShipVersion.Advanced:
          {
            customModulesSlot[0] = [ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.AntiSubmarine];
            customModulesSlot[1] =
            [
              ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine
            ];
            customModulesSlot[2] =
            [
              ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine
            ];
            customModulesSlot[3] =
            [
              ModuleType.LightBattery, ModuleType.AntiAir, ModuleType.Mine, ModuleType.Torpedo, ModuleType.AntiSubmarine
            ];
            customModulesSlot[4] = [ModuleType.None];
            customModulesSlot[5] = [ModuleType.None];
            customModulesSlot[6] = [ModuleType.None];
            break;
          }
      }

      foreach (ModuleType[] slot in customModulesSlot)
      {
        if (slot[0] == ModuleType.None)
        {
          continue;
        }

        ModuleType type = slot[rnd.Next(0, slot.Length)];
        customModules.Add(type, new VanillaModule().CreateModule(type));
      }

      return customModules;
    }

    private static Dictionary<ModuleType, VanillaModule?> GetCruiserCustomsModules(
      VanillaShip.ShipSubType? subType,
      ShipVersion version)
    {
      var rnd = new Random();
      Dictionary<ModuleType, VanillaModule?> customModules = new();
      var customModulesSlot = new ModuleType[7][];

      if (version == ShipVersion.Panzerschiff)
      {
        customModulesSlot[0] = [ModuleType.AntiAir];
        customModulesSlot[1] = [ModuleType.AntiAir, ModuleType.Aircraft, ModuleType.Secondary];
        customModulesSlot[2] = [ModuleType.AntiAir, ModuleType.Aircraft, ModuleType.Secondary];
        customModulesSlot[3] = [ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.Secondary, ModuleType.Torpedo];
      }
      else
      {
        switch (version)
        {
          case ShipVersion.Early:
            customModulesSlot[0] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.Secondary, ModuleType.Torpedo,
              ModuleType.LightBattery
            ];
            customModulesSlot[1] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.Secondary, ModuleType.Torpedo,
              ModuleType.LightBattery
            ];
            customModulesSlot[2] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.AntiSubmarine, ModuleType.LightBattery
            ];
            customModulesSlot[3] = [ModuleType.None];
            customModulesSlot[4] = [ModuleType.None];
            customModulesSlot[5] = [ModuleType.None];
            customModulesSlot[6] = [ModuleType.None];
            break;

          case ShipVersion.Basic:
            customModulesSlot[0] = [ModuleType.AntiAir, ModuleType.LightBattery];
            customModulesSlot[1] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.Secondary, ModuleType.Torpedo,
              ModuleType.LightBattery, ModuleType.AntiSubmarine
            ];
            customModulesSlot[2] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.Secondary, ModuleType.Torpedo,
              ModuleType.LightBattery, ModuleType.AntiSubmarine
            ];
            customModulesSlot[3] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.LightBattery, ModuleType.AntiSubmarine
            ];
            customModulesSlot[4] = [ModuleType.None];
            customModulesSlot[5] = [ModuleType.None];
            customModulesSlot[6] = [ModuleType.None];
            break;

          case ShipVersion.Improved:
          case ShipVersion.Advanced:
            customModulesSlot[0] = [ModuleType.AntiAir, ModuleType.LightBattery];
            customModulesSlot[1] =
            [
              ModuleType.AntiAir, ModuleType.Aircraft, ModuleType.Secondary, ModuleType.Torpedo, ModuleType.LightBattery
            ];
            customModulesSlot[2] =
            [
              ModuleType.AntiAir, ModuleType.Aircraft, ModuleType.Secondary, ModuleType.Torpedo, ModuleType.LightBattery
            ];
            customModulesSlot[3] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.LightBattery, ModuleType.AntiSubmarine
            ];
            customModulesSlot[4] =
            [
              ModuleType.AntiAir, ModuleType.Mine, ModuleType.Aircraft, ModuleType.LightBattery, ModuleType.AntiSubmarine
            ];
            customModulesSlot[5] = [ModuleType.None];
            customModulesSlot[6] = [ModuleType.None];
            break;
        }
      }

      // Add HeavyBattery to all non-None slots for Heavy Cruisers
      if (subType == VanillaShip.ShipSubType.HeavyCruiser)
      {
        for (int i = 0; i < customModulesSlot.Length; i++)
        {
          if (customModulesSlot[i][0] != ModuleType.None)
          {
            // Create a new array with HeavyBattery added
            var expandedSlot = new ModuleType[customModulesSlot[i].Length + 1];
            customModulesSlot[i].CopyTo(expandedSlot, 0);
            expandedSlot[customModulesSlot[i].Length] = ModuleType.HeavyBattery;
            customModulesSlot[i] = expandedSlot;
          }
        }
      }

      // Select random module from each slot
      foreach (ModuleType[] slot in customModulesSlot)
      {
        if (slot[0] == ModuleType.None)
        {
          continue;
        }

        ModuleType type = slot[rnd.Next(0, slot.Length)];
        customModules.Add(type, new VanillaModule().CreateModule(type));
      }

      return customModules;
    }
  }
}