namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;

public class Cannon
{
    private readonly BaseCannon _implementation;
    
    public Cannon()
    {
        _implementation = CannonFactory.CreateCannon();
    }
    
    // Method to get the actual implementation (for mod-specific operations)
    public T GetImplementation<T>() where T : BaseCannon
    {
        return _implementation as T;
    }

    // Method to access mod-specific properties safely
    public bool TryGetImplementation<T>(out T implementation) where T : BaseCannon
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