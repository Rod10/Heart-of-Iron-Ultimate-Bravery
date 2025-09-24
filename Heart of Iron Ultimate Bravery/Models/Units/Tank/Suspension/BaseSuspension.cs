namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Suspension;

public abstract class BaseSuspension
{
    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract string GetModIdentifier();
}