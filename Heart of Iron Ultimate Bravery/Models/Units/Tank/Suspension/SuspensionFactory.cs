using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Suspension;

public class SuspensionFactory
{
    public static BaseSuspension CreateSuspension()
    {
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!;
        string mod = settings.CurrentMod.Short;

        return mod switch
        {
            "vanilla" => new VanillaSuspension(),
            // "kaiserreich" =>
            // "rod56" =>
            // "millenniumdawn" =>
            _ => new VanillaSuspension()
        };
    }
}