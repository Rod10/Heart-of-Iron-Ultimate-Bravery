using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship
{
  public abstract class BaseShip
  {
    public ShipType Type { get; set; }

    public ShipVersion Version { get; set; }

    public string IconName { get; set; }

    public string Name { get; set; }

    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();

    public abstract string GetModIdentifier();
  }
}