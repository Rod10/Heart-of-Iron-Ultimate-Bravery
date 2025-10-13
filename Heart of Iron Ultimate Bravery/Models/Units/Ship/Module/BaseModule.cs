namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship.Module
{
  public abstract class BaseModule
  {
    // Abstract methods that each mod implementation must provide
    public abstract void InitializeModSpecificProperties();

    public abstract string GetModIdentifier();
  }
}