using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;

public class VanillaTurret : BaseTurret
{

    public int Crew;
    public List<VanillaCannon.CannonSize> AllowedCannon;
    
    public VanillaTurret(TurretType type)
    {
        Random rnd = new Random();
        Type = type;
        Console.WriteLine("Turret Type: " + Type);

        string fileName = "Data/Mods/Vanilla/Data/Tank/Turret.json";
        string jsonString = File.ReadAllText(fileName);
        JsonObject jsonData = JsonSerializer.Deserialize<JsonObject>(jsonString)!;
        JsonObject jsonTurret = JsonSerializer.Deserialize<JsonObject>(jsonData[Type.ToString().ToLower()]["crew"])!;
        Crew = rnd.Next(0, jsonTurret.Count);
        Console.WriteLine("Crew: " + Crew);
        List<string> allowedCannon = JsonSerializer.Deserialize<List<string>>(jsonTurret[Crew]["allowedGun"]);
        AllowedCannon = allowedCannon.Select(x => (VanillaCannon.CannonSize) Enum.Parse(typeof(VanillaCannon.CannonSize), x.FirstCharToUpper())).ToList();
    }
    
    public override void InitializeModSpecificProperties()
    {
    }

    public override string GetModIdentifier() => "vanilla";

    public static List<TurretType> GetAllowedTurret(TankType type)
    {
        return type switch
        {
            TankType.Light => [TurretType.Light],
            TankType.Medium => [TurretType.Medium],
            TankType.Heavy => [TurretType.Light, TurretType.Medium, TurretType.Large],
            TankType.SuperHeavy => [TurretType.Light, TurretType.Medium, TurretType.Large, TurretType.SuperHeavy],
            TankType.Modern => [TurretType.Light, TurretType.Medium, TurretType.Large],
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}