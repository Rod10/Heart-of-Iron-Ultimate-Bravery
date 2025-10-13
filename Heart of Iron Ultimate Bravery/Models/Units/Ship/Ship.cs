using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship
{
  public class Ship
  {
    private readonly BaseShip _implementation;

    public Ship(ShipType shipType)
    {
      _implementation = ShipFactory.CreateShip(shipType);
    }

    public ShipType Type
    {
      get => _implementation.Type;
      set => _implementation.Type = value;
    }

    public ShipVersion Version
    {
      get => _implementation.Version;
      set => _implementation.Version = value;
    }

    // Method to get the actual implementation (for mod-specific operations)
    public T GetImplementation<T>() where T : BaseShip
    {
      return _implementation as T;
    }

    // Method to access mod-specific properties safely
    public bool TryGetImplementation<T>(out T implementation) where T : BaseShip
    {
      implementation = _implementation as T;
      return implementation != null;
    }

    // Get current mod identifier
    public string GetModIdentifier()
    {
      return _implementation.GetModIdentifier();
    }
  }
}