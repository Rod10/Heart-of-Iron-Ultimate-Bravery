using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Country
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public bool IsMajor { get; set; }
    
    public JObject Ideas { get; set; }

    public Dictionary<TankType, dynamic> Tanks { get; set; }
    
    public Country(JToken jCountry)
    {
        ISettings settings = ServiceCollectionExtensions.GetService<ISettings>()!;
        Name = jCountry["name"]?.ToString();
        Tag = jCountry["tag"]?.ToString();
        IsMajor = jCountry["isMajor"]?.ToObject<bool>() ?? false;

        string ideasFilePath = $"./Data/Mods/{settings.CurrentMod.Name}/Files/Game/ideas/{jCountry["ideas"]}.txt";
    
        if (File.Exists(ideasFilePath))
        {
            string file = File.ReadAllText(ideasFilePath);
            try
            {
                Ideas = JObject.Parse(HoiIdeasParser.ConvertToJson(file));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // How to add something into the Ideas JObject
        /* string testString = @"{'test': 'a'}";
        var test = JObject.Parse(testString);
        Ideas["ideas"]["country"]["test"] = test;
        string hoi4Result = HoiIdeasParser.ConvertFromJson(Ideas.ToString());
        Console.WriteLine(hoi4Result); */

        InitializeTankDictionary(settings.CurrentMod.Short);
        
    }    
    
    private void InitializeTankDictionary(string mod)
    {
        Tanks = new Dictionary<TankType, dynamic>();
        
        Type enumType = GetEnumTypeForMod<TankType>(mod);
        if (enumType != null)
        {
            foreach (var enumValue in Enum.GetValues(enumType))
            {
                if (Enum.TryParse<TankType>(enumValue.ToString(), out var tankType))
                {
                    Tanks[tankType] = new object();
                }
            }
        }
    }

    private Type GetEnumTypeForMod<T>(string mod) where T : Enum
    {
        string baseTypeName = typeof(T).Name;
        string modEnumTypeName = mod switch
        {
            "vanilla" => $"Vanilla{baseTypeName}",
            "kaiserreich" => $"Kaiserreich{baseTypeName}",
            "road56" => $"Road56{baseTypeName}",
            _ => $"Vanilla{baseTypeName}" // Default fallback
        };

        // Get the enum type by name from current assembly
        return Type.GetType(modEnumTypeName) ?? typeof(T);
    }
}