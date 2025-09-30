using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;

public class VanillaCannon : BaseCannon
{
    public enum CannonSize
    {
        Small,
        Medium,
        Large,
        Bfg
    }

    public enum CannonType
    {
        Cannon,
        Flamethrower,
        FastFiringAntiGround,
        AntiTank,
        AntiAir,
        AntiInfantry
    }

    public static readonly CannonType[] CannonTypes =
    {
        CannonType.Cannon,
        CannonType.Flamethrower,
        CannonType.FastFiringAntiGround,
        CannonType.AntiTank,
        CannonType.AntiAir,
        CannonType.AntiInfantry
    };

    public enum CannonSubType
    {
        SmallCannon,
        MediumCannon,
        HeavyCannon,
        SuperHeavyCannon,
        Flamethrower,
        Hmg,
        AutomaticCannon,
        HighVelocitySmall,
        HighVelocityMedium,
        HighVelocityLarge,
        CloseSupportGun,
        MediumHowitzer,
        HeavyHowitzer,
        RocketLauncher,
        AntiAirSmall,
        AntiAirMedium
    }

    public enum CannonVersion
    {
        Basic,
        Improved,
        Advanced
    }
    
    public CannonSize Size;
    public CannonType Type;
    public CannonSubType SubType;
    public List<VanillaTank.TankRole> allowedRoles = new();
    public CannonVersion Version;

    public VanillaCannon()
    {}
    

    public override void InitializeModSpecificProperties()
    {
        // Initialize vanilla-specific defaults
        // specialModule = new List<SpecialModule>();
        // engineLevel = 1;
        // armorLevel = 1;
    }

    public override void InitializeModSpecificProperties(List<CannonSize> allowedCannonSize)
    {
        Console.WriteLine("/** Cannon **/");
        Random rnd = new Random();
        Size =  allowedCannonSize[rnd.Next(0, allowedCannonSize.Count)];
        Console.WriteLine("Size: " + Size);
        GetAllowedCannonType();
        Console.WriteLine("Type: " + Type);
        GetCannonSubType();
        Console.WriteLine("SubType: " + SubType);
        GetAllowedRoles();
        GetCannonVersion();
        Console.WriteLine("Version: " + Version);
        Console.WriteLine("/** Cannon **/");
    }

    public override string GetModIdentifier() => "vanilla";

    private void GetAllowedCannonType()
    {
        Random rnd = new Random();
        List<CannonType>  allowedCannonType = new List<CannonType>();
        JsonObject jsonData = GetJsonData();

        foreach (CannonType cannonType in CannonTypes)
        {
            string cannonTypeString = cannonType.ToString().FirstCharToLower();
            var cannonTypeData = JsonSerializer.Deserialize<JsonObject>(jsonData[cannonTypeString])!;
            foreach (var (key, value) in cannonTypeData)
            {
                if (value["size"].ToString().Contains(Size.ToString().ToLower()))
                {
                    allowedCannonType.Add(cannonType);
                }
            }
        }

        Type = allowedCannonType[rnd.Next(0, allowedCannonType.Count)];
    }

    private void GetCannonSubType()
    {
        Random rnd = new Random();
        List<CannonSubType> allowedCannonSubType = new List<CannonSubType>();
        JsonObject cannonTypeData = GetJsonData(Type);
        foreach (var (key, value) in cannonTypeData)
        {
            if (value["size"].ToString().Contains(Size.ToString().ToLower()))
            {
                allowedCannonSubType.Add(Enum.Parse<CannonSubType>(key.FirstCharToUpper()));
            }
        }
        
        SubType = allowedCannonSubType[rnd.Next(0, allowedCannonSubType.Count)];
    }

    private void GetAllowedRoles()
    {
        Random rnd = new Random();
        JsonObject cannonData = GetJsonData(Type, SubType);
        JsonArray allowedRolesData = JsonSerializer.Deserialize<JsonArray>(cannonData["roleAllowed"]!);
        foreach (var role in allowedRolesData)
        {
            allowedRoles.Add(Enum.Parse<VanillaTank.TankRole>(role.ToString().FirstCharToUpper()));
        }
    }

    private void GetCannonVersion()
    {
        Random rnd = new Random();
        JsonObject cannonData = GetJsonKeyData(Type, SubType, "type");
        List<CannonVersion> possibleCannonVersions = new List<CannonVersion>();
        foreach (var (key, value) in cannonData)
        {
            possibleCannonVersions.Add(Enum.Parse<CannonVersion>(key.FirstCharToUpper()));
        }
        Version = possibleCannonVersions[rnd.Next(0, possibleCannonVersions.Count)];
    }

    private JsonObject GetJsonData()
    {
        string fileName = "Data/Mods/Vanilla/Data/Tank/Cannon.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<JsonObject>(jsonString)!;
    }
    
    private JsonObject GetJsonData(CannonType type)
    {
        JsonObject jsonData = GetJsonData();
        return JsonSerializer.Deserialize<JsonObject>(jsonData[type.ToString().FirstCharToLower()])!;
    }

    private JsonObject GetJsonData(CannonType type, CannonSubType subType)
    {
        JsonObject jsonData = GetJsonData();
        return JsonSerializer.Deserialize<JsonObject>(jsonData[type.ToString().FirstCharToLower()][SubType.ToString().FirstCharToLower()])!;
    }

    private JsonObject GetJsonKeyData(CannonType type, CannonSubType subType, string? key)
    {
        JsonObject jsonData = GetJsonData();
        return JsonSerializer.Deserialize<JsonObject>(jsonData[type.ToString().FirstCharToLower()][SubType.ToString().FirstCharToLower()][key])!;
    }
}