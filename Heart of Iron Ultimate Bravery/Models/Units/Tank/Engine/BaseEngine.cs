namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Engine;

public abstract class BaseEngine
{
    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract string GetModIdentifier();
}