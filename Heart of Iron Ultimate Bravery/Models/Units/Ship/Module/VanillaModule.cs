using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;

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
      None,
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

    public static readonly ModuleType[] HasSubType =
    [
      ModuleType.LightBattery,
      ModuleType.Mine,
      ModuleType.Secondary
    ];

    public static List<KeyValuePair<ModuleType, VanillaModule?>> GetFixedModule(ShipType type, ShipVersion version, VanillaShip.ShipSubType? subType)
    {
      return type switch
      {
        ShipType.Destroyer => new List<KeyValuePair<ModuleType, VanillaModule?>>
        {
          new(ModuleType.LightBattery, new VanillaModule().CreateModule(type, ModuleType.LightBattery)),
          new(ModuleType.AntiAir, new VanillaModule().CreateModule(type, ModuleType.AntiAir)),
          new(ModuleType.FireControl, new VanillaModule().CreateModule(type, ModuleType.FireControl)),
          new(ModuleType.Sonar, new VanillaModule().CreateModule(type, ModuleType.Sonar)),
          new(ModuleType.Torpedo, new VanillaModule().CreateModule(type, ModuleType.Torpedo)),
          new(ModuleType.Engine, new VanillaModule().CreateModule(type, ModuleType.Engine)),
          new(ModuleType.None, null),
        },
        ShipType.Cruiser => subType switch
        {
          VanillaShip.ShipSubType.LightCruiser => new List<KeyValuePair<ModuleType, VanillaModule?>>
          {
            new(ModuleType.LightBattery, new VanillaModule().CreateModule(type, ModuleType.LightBattery)),
            new(ModuleType.AntiAir, new VanillaModule().CreateModule(type, ModuleType.AntiAir)),
            new(ModuleType.FireControl, new VanillaModule().CreateModule(type, ModuleType.FireControl)),
            new(ModuleType.Sonar, new VanillaModule().CreateModule(type, ModuleType.Sonar)),
            new(ModuleType.Torpedo, new VanillaModule().CreateModule(type, ModuleType.Torpedo)),
            new(ModuleType.Engine, new VanillaModule().CreateModule(type, ModuleType.Engine)),
            new(ModuleType.None, null),
          },
          VanillaShip.ShipSubType.HeavyCruiser => new List<KeyValuePair<ModuleType, VanillaModule?>>
          {
            new(ModuleType.HeavyBattery, new VanillaModule().CreateModule(type, ModuleType.HeavyBattery, VanillaShip.ShipSubType.HeavyCruiser)),
            new(ModuleType.AntiAir, new VanillaModule().CreateModule(type, ModuleType.AntiAir)),
            new(ModuleType.FireControl, new VanillaModule().CreateModule(type, ModuleType.FireControl)),
            new(ModuleType.Sonar, new VanillaModule().CreateModule(type, ModuleType.Sonar)),
            new(ModuleType.Torpedo, new VanillaModule().CreateModule(type, ModuleType.Torpedo)),
            new(ModuleType.Engine, new VanillaModule().CreateModule(type, ModuleType.Engine)),
            new(ModuleType.None, null),
          },
          _ => throw new ArgumentException("Invalid ShipSubType"),
        },
        ShipType.Battleship => subType switch
        {
          VanillaShip.ShipSubType.Battlecruiser => new List<KeyValuePair<ModuleType, VanillaModule?>>
          {
            new(ModuleType.HeavyBattery, new VanillaModule().CreateModule(type, ModuleType.HeavyBattery, VanillaShip.ShipSubType.Battlecruiser)),
            new(ModuleType.AntiAir, new VanillaModule().CreateModule(type, ModuleType.AntiAir)),
            new(ModuleType.FireControl, new VanillaModule().CreateModule(type, ModuleType.FireControl)),
            new(ModuleType.Radar, new VanillaModule().CreateModule(type, ModuleType.Radar)),
            new(ModuleType.Torpedo, new VanillaModule().CreateModule(type, ModuleType.Torpedo)),
            new(ModuleType.Engine, new VanillaModule().CreateModule(type, ModuleType.Engine)),
            new(ModuleType.Armor, new VanillaModule().CreateModule(type, ModuleType.Armor, VanillaShip.ShipSubType.Battlecruiser)),
          },
          VanillaShip.ShipSubType.Battleship => new List<KeyValuePair<ModuleType, VanillaModule?>>
          {
            new(ModuleType.HeavyBattery, new VanillaModule().CreateModule(type, ModuleType.HeavyBattery, VanillaShip.ShipSubType.Battleship)),
            new(ModuleType.AntiAir, new VanillaModule().CreateModule(type, ModuleType.AntiAir)),
            new(ModuleType.FireControl, new VanillaModule().CreateModule(type, ModuleType.FireControl)),
            new(ModuleType.Radar, new VanillaModule().CreateModule(type, ModuleType.Radar)),
            new(ModuleType.Torpedo, new VanillaModule().CreateModule(type, ModuleType.Torpedo)),
            new(ModuleType.Engine, new VanillaModule().CreateModule(type, ModuleType.Engine)),
            new(ModuleType.Armor, new VanillaModule().CreateModule(type, ModuleType.Armor, VanillaShip.ShipSubType.Battleship)),
          },
          VanillaShip.ShipSubType.SuperHeavyBattleship => new List<KeyValuePair<ModuleType, VanillaModule?>>
          {
            new(ModuleType.HeavyBattery, new VanillaModule().CreateModule(type, ModuleType.HeavyBattery, VanillaShip.ShipSubType.SuperHeavyBattleship)),
            new(ModuleType.AntiAir, new VanillaModule().CreateModule(type, ModuleType.AntiAir)),
            new(ModuleType.FireControl, new VanillaModule().CreateModule(type, ModuleType.FireControl)),
            new(ModuleType.Radar, new VanillaModule().CreateModule(type, ModuleType.Radar)),
            new(ModuleType.Torpedo, new VanillaModule().CreateModule(type, ModuleType.Torpedo)),
            new(ModuleType.Engine, new VanillaModule().CreateModule(type, ModuleType.Engine)),
            new(ModuleType.Armor, new VanillaModule().CreateModule(type, ModuleType.Armor)),
          },
          _ => throw new ArgumentException("Invalid ShipSubType"),
        },
        ShipType.Carrier => new List<KeyValuePair<ModuleType, VanillaModule?>>
        {
          new(ModuleType.Aircraft, new VanillaModule().CreateModule(type, ModuleType.Aircraft)),
          new(ModuleType.Aircraft, new VanillaModule().CreateModule(type, ModuleType.Aircraft)),
          new(ModuleType.AntiAir, new VanillaModule().CreateModule(type, ModuleType.AntiAir)),
          new(ModuleType.Radar, new VanillaModule().CreateModule(type, ModuleType.Radar)),
          new(ModuleType.Engine, new VanillaModule().CreateModule(type, ModuleType.Engine)),
          new(ModuleType.Secondary, new VanillaModule().CreateModule(type, ModuleType.Secondary)),
          new(ModuleType.Armor, new VanillaModule().CreateModule(type, ModuleType.Armor)),
        },
        _ => throw new ArgumentException("Invalid ShipType"),
      };
    }

    public static List<KeyValuePair<ModuleType, VanillaModule?>> GetCustomsModule(ShipType type,
      VanillaShip.ShipSubType? subType, ShipVersion version)
    {
      return type switch
      {
        ShipType.Destroyer => GetDestroyerCustomsModules(version),
        ShipType.Cruiser => GetCruiserCustomsModules(subType, version),
        _ => throw new ArgumentException("Invalid ShipType"),
      };
    }

    public VanillaModule CreateModule(ShipType shipType, ModuleType moduleType)
    {
      Random rnd = new Random();
      Type = moduleType;
      JsonObject jsonData = GetJsonData(moduleType);
      List<string> allowedModule = new();
      foreach (KeyValuePair<string, JsonNode?> subObj in jsonData)
      {
        if (subObj.Key.Contains(shipType.ToString().FirstCharToLower()))
        {
          allowedModule.Add(subObj.Key);
        }
      }

      string choosenModule = allowedModule[rnd.Next(0, allowedModule.Count)];
      jsonData = JsonSerializer.Deserialize<JsonObject>(jsonData[choosenModule])!;

      if (HasSubType.Contains(moduleType))
      {
        List<string> allowedSubType = new();
        foreach (KeyValuePair<string, JsonNode?> subObj in jsonData)
        {
          allowedSubType.Add(subObj.Key);
        }

        SubType = Enum.Parse<ModuleSubType>(allowedSubType[rnd.Next(0, allowedSubType.Count)].FirstCharToUpper());
        jsonData = JsonSerializer.Deserialize<JsonObject>(jsonData[SubType.ToString().FirstCharToLower()])!;
      }

      List<string> allowedVersion = new();
      foreach (KeyValuePair<string, JsonNode?> subObj in jsonData)
      {
        allowedVersion.Add(subObj.Key);
      }

      Version = Enum.Parse<ModuleVersion>(allowedVersion[rnd.Next(0, allowedVersion.Count)].FirstCharToUpper());

      return this;
    }

    public VanillaModule CreateModule(ShipType shipType, ModuleType moduleType, VanillaShip.ShipSubType? subType)
    {
      Type = moduleType;
      JsonObject jsonData = GetJsonData(moduleType);
      List<string> keysAllowed = new();
      foreach (KeyValuePair<string, JsonNode?> subObj in jsonData)
      {
        if (subObj.Key.Contains(subType.ToString().FirstCharToLower()))
        {
          keysAllowed.Add(shipType.ToString().FirstCharToLower());
        }
      }

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

    private JsonObject GetJsonData(ModuleType type)
    {
      string fileName = $"Data/Mods/Vanilla/Data/Ship/{type.ToString()}.json";
      string jsonString = File.ReadAllText(fileName);
      return JsonSerializer.Deserialize<JsonObject>(jsonString)!;
    }

    private static List<KeyValuePair<ModuleType, VanillaModule?>> GetDestroyerCustomsModules(ShipVersion version)
    {
      var rnd = new Random();
      List<KeyValuePair<ModuleType, VanillaModule?>> customModules = new List<KeyValuePair<ModuleType, VanillaModule?>>();
      var customModulesSlot = new ModuleType[7][];
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
        customModules.Add(new KeyValuePair<ModuleType, VanillaModule?>(type, new VanillaModule().CreateModule(ShipType.Destroyer, type)));
      }

      return customModules;
    }

    private static List<KeyValuePair<ModuleType, VanillaModule?>> GetCruiserCustomsModules(
      VanillaShip.ShipSubType? subType,
      ShipVersion version)
    {
      var rnd = new Random();
      List<KeyValuePair<ModuleType, VanillaModule?>> customModules = new();
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
        customModules.Add(new KeyValuePair<ModuleType, VanillaModule?>(type, new VanillaModule().CreateModule(ShipType.Cruiser, type, subType)));
      }

      return customModules;
    }
  }
}