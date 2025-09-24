namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Armor;

public abstract class BaseArmor
{
    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract string GetModIdentifier();
}