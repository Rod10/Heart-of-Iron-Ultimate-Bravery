using System;
using System.Collections.Generic;
using System.Linq;
using DynamicData;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.SpecialModule;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public class VanillaTank : BaseTank
{
    public enum TankRole
    {
        Tank,
        TankDestroyer,
        SpArtillery,
        SpAA,
        FlameTank
    }

    public TankRole Role;
    // Vanilla-specific properties
    public List<SpecialModule.SpecialModule> SpecialModules { get; set; } = new(4);
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
        cannon.GetImplementation<VanillaCannon>().InitializeModSpecificProperties(allowedCannon);
        List<TankRole> allowedRoles = cannon.GetImplementation<VanillaCannon>().allowedRoles;
        Role = allowedRoles[rnd.Next(0, allowedRoles.Count)];
        Console.WriteLine("Role: " + Role);
        List<VanillaSpecialModule.SpecialModuleType> types = VanillaSpecialModule.Types;
        for (int i = 0; i < SpecialModules.Capacity; i++)
        {
            var type = types[rnd.Next(0, types.Count)];
            if (VanillaSpecialModule.RestrictedModule.Contains(type))
            {
                if (type == VanillaSpecialModule.SpecialModuleType.BasicRadio
                    || type == VanillaSpecialModule.SpecialModuleType.ImprovedRadio
                    || type == VanillaSpecialModule.SpecialModuleType.AdvancedRadio)
                {
                    types.Remove(VanillaSpecialModule.SpecialModuleType.BasicRadio);
                    types.Remove(VanillaSpecialModule.SpecialModuleType.ImprovedRadio);
                    types.Remove(VanillaSpecialModule.SpecialModuleType.AdvancedRadio);
                } 
                else 
                {
                    types.Remove(type);
                }
            }
            Console.WriteLine("Special Module Type: " + type);
            //types[types.IndexOf(type)] = null;
        }
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
