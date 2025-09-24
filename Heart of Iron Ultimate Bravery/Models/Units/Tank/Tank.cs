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

    public Suspension.Suspension Suspension
    {
        get => _implementation.Suspension;
        set => _implementation.Suspension = value;
    }

    public Engine.Engine Engine
    {
        get => _implementation.Engine;
        set => _implementation.Engine = value;
    }

    public Armor.Armor Armor
    {
        get => _implementation.Armor;
        set => _implementation.Armor = value;
    }

    /*public Stats stats
    {
        get => _implementation.stats;
        set => _implementation.stats = value;
    }*/

    public string IconName
    {
        get => _implementation.IconName;
        set => _implementation.IconName = value;
    }

    public string Name
    {
        get => _implementation.Name;
        set => _implementation.Name = value;
    }

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