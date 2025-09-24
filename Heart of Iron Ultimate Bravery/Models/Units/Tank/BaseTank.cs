using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public abstract class BaseTank
{
    public TankType Type { get; set; }
    public TankVersion Version { get; set; }
    public Turret.Turret Turret { get; set; }
    public Cannon.Cannon Cannon { get; set; }
    public Suspension.Suspension Suspension { get; set; }
    public Engine.Engine Engine { get; set; }
    public Armor.Armor Armor { get; set; }
    // public Stats stats { get; set; }
    public string IconName { get; set; }
    public string Name { get; set; }

    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract string GetModIdentifier();
}