namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship.Module
{
  public class Module
  {
    private readonly BaseModule _implementation;

    public Module()
    {
      _implementation = ModuleFactory.CreateModule();
    }
    
    // Method to get the actual implementation (for mod-specific operations)
    public T GetImplementation<T>() where T : BaseModule
    {
      return _implementation as T;
    }

    // Method to access mod-specific properties safely
    public bool TryGetImplementation<T>(out T implementation) where T : BaseModule
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