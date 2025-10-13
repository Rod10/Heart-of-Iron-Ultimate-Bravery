using System;
using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship.Module;
using Tmds.DBus.Protocol;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship
{
  public class VanillaShip : BaseShip
  {
    public enum ShipSubType
    {
      LightCruiser,
      HeavyCruiser,
      Battlecruiser,
      Battleship,
      SuperHeavyBattleship,
    }
    
    public ShipSubType? SubType;
    
    public Dictionary<VanillaModule.ModuleType, VanillaModule?> FixedModule;
    public Dictionary<VanillaModule.ModuleType, VanillaModule?> CustomModule;

    private static readonly ShipVersion[] _destroyerVersions =
    [
      ShipVersion.Early, ShipVersion.Basic, ShipVersion.Improved, ShipVersion.Advanced
    ];

    private static readonly ShipVersion[] _cruiserVersions =
    [
      ShipVersion.Early, ShipVersion.Basic, ShipVersion.Improved, ShipVersion.Advanced, ShipVersion.TorpedoCruiser,
      ShipVersion.Panzerschiff, ShipVersion.CoastalDefenseShip
    ];

    private static readonly ShipVersion[] _battleshipVersions =
    [
      ShipVersion.PreDreadnought, ShipVersion.Early, ShipVersion.Basic, ShipVersion.Improved, ShipVersion.Advanced,
      ShipVersion.SuperHeavy, ShipVersion.Modern,
    ];

    private static readonly ShipVersion[] _carrierVersions =
    [
      ShipVersion.ConvertedCruiser, ShipVersion.ConverterBattleship, ShipVersion.Early, ShipVersion.Basic,
      ShipVersion.Improved, ShipVersion.Advanced, ShipVersion.Ice, ShipVersion.Modern
    ];

    private static readonly ShipVersion[] _submarineVersion =
    [
      ShipVersion.Early, ShipVersion.Basic, ShipVersion.Improved, ShipVersion.Advanced, ShipVersion.Midget,
      ShipVersion.Cruiser, ShipVersion.Fleet, ShipVersion.Nuclear
    ];

    public VanillaShip(ShipType type)
    {
      Random rnd = new Random();
      Type = type;
      Console.WriteLine($@"Type: {Type}");
      ShipVersion[] shipVersionsAllowedForType = GetAllowedVersionsForType(type);
      Version = shipVersionsAllowedForType[rnd.Next(0, shipVersionsAllowedForType.Length)];
      Console.WriteLine($@"Version: {Version}");

      if (Version == ShipVersion.Panzerschiff)
      {
        SubType = ShipSubType.HeavyCruiser;
      }
      else
      {
        ShipSubType[] shipAllowedSubTypes = GetAllowedSubType(Type);
        SubType = shipAllowedSubTypes[rnd.Next(0, shipAllowedSubTypes.Length)];
      }

      Console.WriteLine($@"ShipSubType: {SubType}");

      FixedModule = VanillaModule.GetFixedModule(Type, Version, SubType);
      Console.WriteLine(@"/** FixedModule **/");
      foreach (KeyValuePair<VanillaModule.ModuleType, VanillaModule> module in FixedModule)
      {
        Console.WriteLine($@"{module.Key}: {module.Value.Version}");
      }

      Console.WriteLine(@"/** FixedModule **/");
      CustomModule = VanillaModule.GetCustomsModule(Type, SubType, Version);
    }

    private ShipVersion[] GetAllowedVersionsForType(ShipType type)
    {
      return type switch
      {
        ShipType.Destroyer => _destroyerVersions,
        ShipType.Cruiser => _cruiserVersions,
        ShipType.Battleship => _battleshipVersions,
        ShipType.Carrier => _carrierVersions,
        ShipType.Submarine => _submarineVersion,
        _ => throw new ArgumentException("Invalid ShipType"),
      };
    }

    private ShipSubType[]? GetAllowedSubType(ShipType type)
    {
      return type switch
      {
        ShipType.Destroyer => null,
        ShipType.Cruiser => [ShipSubType.LightCruiser, ShipSubType.HeavyCruiser],
        ShipType.Battleship => [ShipSubType.Battlecruiser, ShipSubType.Battleship, ShipSubType.SuperHeavyBattleship],
        ShipType.Carrier => null,
        ShipType.Submarine => null,
        _ => throw new ArgumentException("Invalid ShipType"),
      };
    }

    public override void InitializeModSpecificProperties()
    {
      // Initialize vanilla-specific defaults
      // specialModule = new List<SpecialModule>();
      // engineLevel = 1;
      // armorLevel = 1;
    }

    public override string GetModIdentifier() => "vanilla";
  }
}