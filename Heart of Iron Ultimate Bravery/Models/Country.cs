using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Tank;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Country<TUnitType>
    where TUnitType : Enum
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public bool IsMajor { get; set; }
    
    public JObject Ideas { get; set; }

    public Dictionary<TankType, object> Tanks { get; set; }
    
    public  Country(JToken jCountry)
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
        Tanks =
    }
}