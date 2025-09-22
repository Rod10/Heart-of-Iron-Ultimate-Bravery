using System;
using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public class VanillaTank : BaseTank
{
    // Vanilla-specific properties
    // public List<SpecialModule> specialModule { get; set; } = new();
    // public int engineLevel { get; set; }
    // public int armorLevel { get; set; }


    public VanillaTank(TankType tankType)
    {
        Random rnd = new Random();
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!;
        Type = tankType;
        TankVersion[] validTankVersion = EnumHelper.GetEnumVersionArrayForMod<TankVersion>(settings.CurrentMod.Short);
        TankVersion tankVersion = validTankVersion[rnd.Next(0, validTankVersion.Length)];
        Version = tankVersion;
        Console.WriteLine("Type: " + Type);
        Console.WriteLine("Version: " + Version);
        List<TurretType> allowedTurrets = VanillaTurret.GetAllowedTurret(Type);
        Turret.Turret turret = new Turret.Turret(allowedTurrets[rnd.Next(0, allowedTurrets.Count)]);
        Cannon.Cannon cannon = new Cannon.Cannon();
        List<VanillaCannon.CannonSize> allowedCannon = turret.GetImplementation<VanillaTurret>().AllowedCannon;
        cannon.GetImplementation<BaseCannon>().InitializeModSpecificProperties(allowedCannon);
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
