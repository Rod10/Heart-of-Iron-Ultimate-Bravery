using System;
using System.Collections.Generic;
using System.Linq;
using DynamicData;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Armor;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Engine;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.SpecialModule;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Suspension;
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
    public int EngineLevel { get; set; }
    public int ArmorLevel { get; set; }
    
    public VanillaTank(TankType tankType)
    {
        Random rnd = new Random();
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        Type = tankType;
        Name = GetNameByType();
        TankVersion[] validTankVersion = EnumHelper.GetEnumVersionArrayForMod<TankVersion>(settings.CurrentMod.Short);
        TankVersion tankVersion = validTankVersion[rnd.Next(0, validTankVersion.Length)];
        Version = tankVersion;
        Console.WriteLine("Type: " + Type);
        Console.WriteLine("Version: " + Version);
        List<TurretType> allowedTurrets = VanillaTurret.GetAllowedTurret(Type);
        Turret = new Turret.Turret(allowedTurrets[rnd.Next(0, allowedTurrets.Count)]);
        Cannon = new Cannon.Cannon();
        List<VanillaCannon.CannonSize> allowedCannon = Turret.GetImplementation<VanillaTurret>().AllowedCannon;
        Cannon.GetImplementation<VanillaCannon>().InitializeModSpecificProperties(allowedCannon);
        List<TankRole> allowedRoles = Cannon.GetImplementation<VanillaCannon>().allowedRoles;
        Role = allowedRoles[rnd.Next(0, allowedRoles.Count)];
        Console.WriteLine("Role: " + Role);
        List<VanillaSpecialModule.SpecialModuleType> types = new List<VanillaSpecialModule.SpecialModuleType>(VanillaSpecialModule.Types);
        Console.WriteLine("/** Special Modules **/");
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
            SpecialModule.SpecialModule specialModule = new SpecialModule.SpecialModule();
            specialModule.GetImplementation<VanillaSpecialModule>().CreateSpecialModule(type);
            SpecialModules.Add(specialModule);
            Console.WriteLine("Type: " + specialModule.GetImplementation<VanillaSpecialModule>().Type);
        }
        Console.WriteLine("/** Special Modules **/");
        Suspension = new Suspension.Suspension();
        Console.WriteLine("Suspension Type: " + Suspension.GetImplementation<VanillaSuspension>().Type);
        Engine = new Engine.Engine();
        Console.WriteLine("EngineType: " + Engine.GetImplementation<VanillaEngine>().Type);
        Armor = new Armor.Armor();
        Console.WriteLine("ArmorType: " + Armor.GetImplementation<VanillaArmor>().Type);
        EngineLevel = rnd.Next(0, 20);
        Console.WriteLine("EngineLevel: " + EngineLevel);
        ArmorLevel = rnd.Next(0, 20);
        Console.WriteLine("ArmorLevel: " + ArmorLevel);
    }

    private string GetNameByType()
    {
        return Type switch
        {
            TankType.Light => "Light Tank",
            TankType.Medium => "Medium Tank",
            TankType.Heavy => "Heavy Tank",
            TankType.Modern => "Modern Tank",
            TankType.SuperHeavy => "Super Heavy Tank",
            _ => "Weird Tank"
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
