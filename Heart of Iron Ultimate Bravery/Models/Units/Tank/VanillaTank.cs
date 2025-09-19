using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public class VanillaTank : BaseTank
{
    // Vanilla-specific properties
    // public List<SpecialModule> specialModule { get; set; } = new();
    // public int engineLevel { get; set; }
    // public int armorLevel { get; set; }

    public override void InitializeModSpecificProperties()
    {
        // Initialize vanilla-specific defaults
        // specialModule = new List<SpecialModule>();
        // engineLevel = 1;
        // armorLevel = 1;
    }

    public override string GetModIdentifier() => "vanilla";
}
