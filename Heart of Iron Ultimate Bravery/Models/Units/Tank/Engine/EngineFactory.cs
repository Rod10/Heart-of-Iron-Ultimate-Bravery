using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Engine;

public class EngineFactory
{ 
    public static BaseEngine CreateEngine() 
    { 
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!; 
        string mod = settings.CurrentMod.Short;
        
        return mod switch 
        { 
            "vanilla" => new VanillaEngine(), 
            // "kaiserreich" => 
            // "rod56" => 
            // "millenniumdawn" => 
            _ => new VanillaEngine() 
        }; 
    }   
}