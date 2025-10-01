using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Cannon;

public static class CannonFactory
{
    public static BaseCannon CreateCannon()
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        string mod = settings.CurrentMod.Short;

        BaseCannon cannon = mod switch
        {
            "vanilla" => new VanillaCannon(),
            // "millenniumdawn" => new MillenniumDawnCannon
            _ => new VanillaCannon()
        };

        return cannon;
    }
}