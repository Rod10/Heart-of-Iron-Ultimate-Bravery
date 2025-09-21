using System;
using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;

public class VanillaTurret : BaseTurret
{

    public int crew;
    
    public VanillaTurret(TurretType type)
    {
        Type = type;
        Console.WriteLine("Turret Type: " + Type);
    }
    
    public override void InitializeModSpecificProperties()
    {
    }

    public override string GetModIdentifier() => "vanilla";

    public static List<TurretType> GetAllowedTurret(TankType type)
    {
        return type switch
        {
            TankType.Light => new List<TurretType>() { TurretType.Light },
            TankType.Medium => new List<TurretType>() { TurretType.Medium },
            TankType.Heavy => new List<TurretType>() { TurretType.Light,  TurretType.Medium , TurretType.Large},
            TankType.SuperHeavy => new List<TurretType>() { TurretType.Light,  TurretType.Medium , TurretType.Large, TurretType.SuperHeavy},
            TankType.Modern => new List<TurretType>() { TurretType.Light,  TurretType.Medium , TurretType.Large},
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}