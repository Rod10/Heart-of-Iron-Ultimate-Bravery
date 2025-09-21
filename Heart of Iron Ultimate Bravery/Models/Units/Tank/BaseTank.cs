using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public abstract class BaseTank
{
    // Common properties for all mods (from your diagram)
    public TankType Type { get; set; }
    public TankVersion Version { get; set; }
    // public Turret Turret { get; set; }
    // public string gun { get; set; }
    // public string suspension { get; set; }
    // public string armor { get; set; }
    // public string engine { get; set; }
    // public Stats stats { get; set; }
    // public string role { get; set; }
    // public string iconName { get; set; }
    // public string name { get; set; }

    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract string GetModIdentifier();
}