using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Turret;

public static class TurretFactory
{
    public static BaseTurret CreateTurret(TurretType tankType)
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>() ?? new Settings();
        string mod = settings.CurrentMod.Short;

        BaseTurret turret = mod switch
        {
            "vanilla" => new VanillaTurret(tankType),
            // "millenniumdawn" => new MillenniumDawnTank(),
            // "blackice" => new BlackIceTank(),
            // "worldablaze" => new WorldAblazeTank(),
            // "greatwarredux" => new GreatWarReduxTank(),
            _ => new VanillaTurret(tankType) // Default fallback
        };
        
        return turret;
    }
}