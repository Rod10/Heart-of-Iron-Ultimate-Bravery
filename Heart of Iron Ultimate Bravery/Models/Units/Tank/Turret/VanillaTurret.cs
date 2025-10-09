using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret
{
  public class VanillaTurret : BaseTurret
  {

    public int Crew;
    public List<VanillaCannon.CannonSize> AllowedCannon;

    public VanillaTurret(TurretType type)
    {
      var rnd = new Random();
      Type = type;
      Console.WriteLine("Turret Type: " + Type);

      string fileName = "Data/Mods/Vanilla/Data/Tank/Turret.json";
      string jsonString = File.ReadAllText(fileName);
      JsonObject jsonData = JsonSerializer.Deserialize<JsonObject>(jsonString)!;
      List<int> allowedCrew = GetAllowedCrew(Type);
      Crew = allowedCrew[rnd.Next(0, allowedCrew.Count)];
      Console.WriteLine("Crew: " + Crew);
      List<string> allowedCannon = jsonData[Type.ToString().FirstCharToLower()]["crew"][Crew.ToString()]["allowedGun"].Deserialize<List<string>>();
      AllowedCannon = allowedCannon.Select(x => (VanillaCannon.CannonSize)Enum.Parse(typeof(VanillaCannon.CannonSize), x.FirstCharToUpper())).ToList();
    }

    public override void InitializeModSpecificProperties()
    {
    }

    public override string GetModIdentifier()
    {
      return "vanilla";
    }

    public static List<TurretType> GetAllowedTurret(TankType type)
    {
      return type switch
      {
        TankType.Light => [TurretType.Light],
        TankType.Medium => [TurretType.Medium],
        TankType.Heavy => [TurretType.Light, TurretType.Medium, TurretType.Large],
        TankType.SuperHeavy => [TurretType.Light, TurretType.Medium, TurretType.Large, TurretType.SuperHeavy],
        TankType.Modern => [TurretType.Light, TurretType.Medium, TurretType.Large, TurretType.Modern],
        _ => throw new ArgumentOutOfRangeException()
      };
    }

    private List<int> GetAllowedCrew(TurretType type)
    {
      return type switch
      {
        TurretType.Light => new List<int>
        {
          0, 1, 2, 3,
        },
        TurretType.Medium => new List<int>
        {
          0, 1, 2, 3,
        },
        TurretType.Large => new List<int>
        {
          0, 2, 3,
        },
        TurretType.SuperHeavy => new List<int>
        {
          3, 4,
        },
        TurretType.Modern => new List<int>
        {
          0,
        },
        _ => new List<int>
        {
          1, 2,
        },
      };
    }
  }
}