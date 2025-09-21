using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;

public abstract class BaseTurret
{
    public TurretType Type { get; set; }
    
    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract string GetModIdentifier();
}