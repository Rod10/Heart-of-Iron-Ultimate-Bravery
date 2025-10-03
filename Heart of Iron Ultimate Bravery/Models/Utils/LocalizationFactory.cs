using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Utils;


public class LocalizationFactory
{
    private readonly Dictionary<string, ResourceManager> _resourceManagers;
    
    public LocalizationFactory()
    {
        var assembly = Assembly.GetExecutingAssembly();
        _resourceManagers = new Dictionary<string, ResourceManager>(StringComparer.OrdinalIgnoreCase)
        {
            ["vanilla"] = new ResourceManager(
                "Heart_of_Iron_Ultimate_Bravery.Assets.Mods.Vanilla.Localization.Resources", 
                assembly),
            // ["kaiserreich"] = Assets.Mods.Kaiserreich.Localization.Resources.ResourceManager,
            // ["road56"] = Assets.Mods.Road56.Localization.Resources.ResourceManager
        };
    }
    
    public void SetCulture(Mod mod, CultureInfo culture)
    {
        if (_resourceManagers.TryGetValue(mod.Short, out var rm))
        {
            // Set culture on the Resources class
            var typeName = $"Assets.Mods.{mod.Name}.Localization.Resources";
            var resourceType = Type.GetType(typeName);
            var cultureProperty = resourceType?.GetProperty("Culture", BindingFlags.Static | BindingFlags.Public);
            cultureProperty?.SetValue(null, culture);
        }
    }
    
    public string GetString(string modName, string key)
    {
        if (_resourceManagers.TryGetValue(modName, out var resourceManager))
        {
            return resourceManager.GetString(key);
        }
        
        throw new ArgumentException($"Unknown mod: {modName}");
    }
}