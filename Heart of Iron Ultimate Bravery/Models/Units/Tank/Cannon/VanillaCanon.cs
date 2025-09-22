using System;
using System.Collections.Generic;

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
    
    public CannonSize Size;
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
        Random rnd = new Random();
        Size =  allowedCannonSize[rnd.Next(0, allowedCannonSize.Count)];
        Console.WriteLine(Size);
        // Initialize vanilla-specific defaults
        // specialModule = new List<SpecialModule>();
        // engineLevel = 1;
        // armorLevel = 1;
    }

    public override string GetModIdentifier() => "vanilla";

    private List<CannonType> GetAllowedCannonType()
    {
        
    }
}