using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Engine;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Armor;

public class ArmorFactory
{ 
    public static BaseArmor CreateArmor() 
    { 
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!; 
        string mod = settings.CurrentMod.Short;
        
        return mod switch 
        { 
            "vanilla" => new VanillaArmor(), 
            // "kaiserreich" => 
            // "rod56" => 
            // "millenniumdawn" => 
            _ => new VanillaArmor() 
        }; 
    }   
}