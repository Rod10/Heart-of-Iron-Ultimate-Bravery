using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;

public class Turret
{
    private readonly BaseTurret _implementation;

    public Turret(TurretType type)
    {
        _implementation = TurretFactory.CreateTurret(type);
    }

    // Expose all common properties through delegation
    public TurretType type
    {
        get => _implementation.Type;
        set => _implementation.Type = value;
    }

    // Method to get the actual implementation (for mod-specific operations)
    public T GetImplementation<T>() where T : BaseTurret
    {
        return _implementation as T;
    }

    // Method to access mod-specific properties safely
    public bool TryGetImplementation<T>(out T implementation) where T : BaseTurret
    {
        implementation = _implementation as T;
        return implementation != null;
    }

    // Get current mod identifier
    public string GetModIdentifier()
    {
        return _implementation.GetModIdentifier();
    }

    // Method to check if tank has specific mod features
    public bool HasModSpecificFeature(string featureName)
    {
        return _implementation.GetModIdentifier() switch
        {
            "blackice" => featureName == "ergonomics" || featureName == "radio",
            "millenniumdawn" => featureName == "reloading" || featureName == "battleStation",
            _ => false
        };
    }
}