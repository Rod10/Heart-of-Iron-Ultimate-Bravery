using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;

public static class TankFactory
{
    public static BaseTank CreateTank(TankType tankType)
    { 
        Settings settings = ServiceCollectionExtensions.GetService<Settings>();
        string mod = settings.CurrentMod.Short;
            
        BaseTank tank = mod switch
        {
            "vanilla" => new VanillaTank(tankType),
            // "millenniumdawn" => new MillenniumDawnTank(),
            // "blackice" => new BlackIceTank(),
            // "worldablaze" => new WorldAblazeTank(),
            // "greatwarredux" => new GreatWarReduxTank(),
            _ => new VanillaTank(tankType) // Default fallback
        };

        tank.InitializeModSpecificProperties();
        return tank;
    }
}