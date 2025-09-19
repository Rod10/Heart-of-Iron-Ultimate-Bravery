using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public static class TankFactory
{
    public static BaseTank CreateTank(TankType tankType)
    { 
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!;
        string mod = settings.CurrentMod.Short;
            
        BaseTank tank = mod switch
        {
            "vanilla" => new VanillaTank(),
            // "millenniumdawn" => new MillenniumDawnTank(),
            // "blackice" => new BlackIceTank(),
            // "worldablaze" => new WorldAblazeTank(),
            // "greatwarredux" => new GreatWarReduxTank(),
            _ => new VanillaTank() // Default fallback
        };

        tank.InitializeModSpecificProperties();
        return tank;
    }
}