using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Country
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public bool IsMajor { get; set; }
    
    public JObject Ideas { get; set; }

    public Dictionary<ShipType, dynamic> Ships { get; set; }
    public Dictionary<TankType, Tank?> Tanks { get; set; }
    public Dictionary<PlaneType, dynamic> Planes { get; set; }
    public Dictionary<DivisionType, dynamic> Divisions { get; set; }
    
    public Country(JToken jCountry)
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>() ?? new Settings();
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
    
    /*private void InitializeShipDictionary(string mod)
    {
        Ships = new Dictionary<ShipType, dynamic>();
        
        Type enumType = GetEnumTypeForMod<ShipType>(mod);
        if (enumType != null)
        {
            foreach (var enumValue in Enum.GetValues(enumType))
            {
                // Parse the enum value to your ShipType enum
                if (Enum.TryParse<ShipType>(enumValue.ToString(), out var shipType))
                {
                    Ships[shipType] = new object(); // Initialize with default or specific values
                }
            }
        }
    }*/

    
    private void InitializeTankDictionary(string mod)
    {
        Tanks = new Dictionary<TankType, Tank?>();
        TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(mod);
            
        foreach (var tankType in validTankTypes)
        {
            Tanks[tankType] = null;
        }
    }

    public void AddTank(Tank tank)
    {
        Settings settings = ServiceCollectionExtensions.GetService<Settings>() ?? new Settings();
        TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(settings.CurrentMod.Short);

        if (validTankTypes.Contains(tank.Type))
        {
            Tanks[tank.Type] = tank;
        }
    }
    
    /*private void InitializePlaneDictionary(string mod)
    {
        Planes = new Dictionary<PlaneType, dynamic>();
        
        Type enumType = GetEnumTypeForMod<PlaneType>(mod);
        if (enumType != null)
        {
            foreach (var enumValue in Enum.GetValues(enumType))
            {
                if (Enum.TryParse<PlaneType>(enumValue.ToString(), out var planeType))
                {
                    Planes[planeType] = new object();
                }
            }
        }
    }*/

    /*private void InitializeDivisionDictionary(string mod)
    {
        Divisions = new Dictionary<DivisionType, dynamic>();
        
        Type enumType = GetEnumTypeForMod<DivisionType>(mod);
        if (enumType != null)
        {
            foreach (var enumValue in Enum.GetValues(enumType))
            {
                if (Enum.TryParse<DivisionType>(enumValue.ToString(), out var divisionType))
                {
                    Divisions[divisionType] = new object();
                }
            }
        }
    }*/
}