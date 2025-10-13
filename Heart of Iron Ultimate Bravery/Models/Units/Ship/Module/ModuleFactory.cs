namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship.Module
{
  public class ModuleFactory
  {
    public static BaseModule CreateModule()
    {
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      string mod = settings.CurrentMod.Short;

      BaseModule module = mod switch
      {
        "vanilla" => new VanillaModule(),
        _ => new VanillaModule(),
      };
      module.InitializeModSpecificProperties();
      return module;
    }
  }
}