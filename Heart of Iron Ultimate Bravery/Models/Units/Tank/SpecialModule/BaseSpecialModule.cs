namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.SpecialModule;

public abstract class BaseSpecialModule
{
    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();
    public abstract void InitializeModSpecificProperties(VanillaSpecialModule.SpecialModuleType type);
    public abstract string GetModIdentifier();
}