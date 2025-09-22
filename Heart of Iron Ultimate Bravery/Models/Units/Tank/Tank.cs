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
    public TankType Type
    {
        get => _implementation.Type;
        set => _implementation.Type = value;
    }

    public TankVersion Version
    {
        get => _implementation.Version;
        set => _implementation.Version = value;
    }

    public Turret.Turret Turret
    {
        get => _implementation.Turret;
        set => _implementation.Turret = value;
    }

    public Cannon.Cannon Cannon
    {
        get => _implementation.Cannon;
        set => _implementation.Cannon = value;
    }

    /*public string suspension
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