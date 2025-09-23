using System;
using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.SpecialModule;

public class VanillaSpecialModule : BaseSpecialModule
{
    public enum SpecialModuleType
    {
        BasicRadio,
        ImprovedRadio,
        AdvancedRadio,
        MachineGuns,
        Amphibious,
        ArmorSkirts,
        AutoLoader,
        DozerBlade,
        Maintenance,
        ExtraAmmo,
        SloppedArmor,
        SmokeLauncher,
        Adaptor,
        Stabilizer,
        WetAmmo
    }

    public static readonly List<SpecialModuleType> Types = new()
    {
        SpecialModuleType.BasicRadio,
        SpecialModuleType.ImprovedRadio,
        SpecialModuleType.AdvancedRadio,
        SpecialModuleType.MachineGuns,
        SpecialModuleType.Amphibious,
        SpecialModuleType.ArmorSkirts,
        SpecialModuleType.AutoLoader,
        SpecialModuleType.DozerBlade,
        SpecialModuleType.Maintenance,
        SpecialModuleType.ExtraAmmo,
        SpecialModuleType.SloppedArmor,
        SpecialModuleType.SmokeLauncher,
        SpecialModuleType.Adaptor,
        SpecialModuleType.Stabilizer,
        SpecialModuleType.WetAmmo
    };

    public static readonly SpecialModuleType[] RestrictedModule =
    {
        SpecialModuleType.BasicRadio,
        SpecialModuleType.ImprovedRadio,
        SpecialModuleType.AdvancedRadio,
        SpecialModuleType.Amphibious,
        SpecialModuleType.ArmorSkirts,
        SpecialModuleType.AutoLoader,
        SpecialModuleType.DozerBlade,
        SpecialModuleType.Maintenance,
        SpecialModuleType.ExtraAmmo,
        SpecialModuleType.SloppedArmor,
        SpecialModuleType.Adaptor,
        SpecialModuleType.Stabilizer,
        SpecialModuleType.WetAmmo
    };
    
    public SpecialModuleType Type;
    public bool OnlyOne;

    public override void InitializeModSpecificProperties()
    {
    }

    public void CreateSpecialModule(SpecialModuleType type)
    {
        
    }

    public override void InitializeModSpecificProperties(SpecialModuleType type)
    {
        Random rnd = new Random();
        // Initialize vanilla-specific defaults
        // specialModule = new List<SpecialModule>();
        // engineLevel = 1;
        // armorLevel = 1;
    }

    public override string GetModIdentifier() => "vanilla";
    
}