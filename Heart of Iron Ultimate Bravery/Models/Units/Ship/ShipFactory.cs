using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship
{
  public static class ShipFactory
  {
    public static BaseShip CreateShip(ShipType shipType)
    {
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      string mod = settings.CurrentMod.Short;

      BaseShip ship = mod switch
      {
        "vanilla" => new VanillaShip(shipType),
        _ => new VanillaShip(shipType),
      };
      ship.InitializeModSpecificProperties();
      return ship;
    }
  }
}