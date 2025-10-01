using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.SpecialModule;

public class SpecialModuleFactory
{
    public static BaseSpecialModule CreateSpecialModule()
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        string mod = settings.CurrentMod.Short;

        return mod switch
        {
            "vanilla" => new VanillaSpecialModule(),
            // "kaiserreich" =>
            // "rod56" =>
            // "millenniumdawn" =>
            _ => new VanillaSpecialModule()
        };
    }
}