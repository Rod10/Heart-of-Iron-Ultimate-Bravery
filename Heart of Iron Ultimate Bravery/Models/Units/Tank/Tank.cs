using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public class Tank
{
    private readonly BaseTank _implementation;

    // Constructor with specific tank type
    public Tank(TankType tankType)
    {
        _implementation = TankFactory.CreateTank(tankType);
    }

    // Expose all common properties through delegation
    public TankType type
    {
        get => _implementation.type;
        set => _implementation.type = value;
    }

    /*public ITankVersion version
    {
        get => _implementation.version;
        set => _implementation.version = value;
    }

    public Turret turret
    {
        get => _implementation.turret;
        set => _implementation.turret = value;
    }

    public string gun
    {
        get => _implementation.gun;
        set => _implementation.gun = value;
    }

    public string suspension
    {
        get => _implementation.suspension;
        set => _implementation.suspension = value;
    }

    public string armor
    {
        get => _implementation.armor;
        set => _implementation.armor = value;
    }

    public string engine
    {
        get => _implementation.engine;
        set => _implementation.engine = value;
    }

    public Stats stats
    {
        get => _implementation.stats;
        set => _implementation.stats = value;
    }

    public string role
    {
        get => _implementation.role;
        set => _implementation.role = value;
    }

    public string iconName
    {
        get => _implementation.iconName;
        set => _implementation.iconName = value;
    }

    public string name
    {
        get => _implementation.name;
        set => _implementation.name = value;
    }*/

    // Method to get the actual implementation (for mod-specific operations)
    public T GetImplementation<T>() where T : BaseTank
    {
        return _implementation as T;
    }

    // Method to access mod-specific properties safely
    public bool TryGetImplementation<T>(out T implementation) where T : BaseTank
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