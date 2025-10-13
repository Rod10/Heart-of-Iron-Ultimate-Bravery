using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Ship;
using Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank;
using Heart_of_Iron_Ultimate_Bravery.Models.Utils;
using Newtonsoft.Json.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Models
{
  public class Country
  {
    public string Name { get; set; }

    public string Tag { get; set; }

    public bool IsMajor { get; set; }

    public JObject Ideas { get; set; }

    public Dictionary<ShipType, Ship?> Ships { get; set; }

    public Dictionary<TankType, Tank?> Tanks { get; set; }

    public Dictionary<PlaneType, dynamic> Planes { get; set; }

    public Dictionary<DivisionType, dynamic> Divisions { get; set; }

    public Country(JToken jCountry)
    {
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
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

      InitializeShipDictionary(settings.CurrentMod.Short);
      InitializeTankDictionary(settings.CurrentMod.Short);
    }

    private void InitializeShipDictionary(string mod)
    {
      Ships = new Dictionary<ShipType, Ship?>();
      ShipType[] validShipTypes = EnumHelper.GetEnumTypeArrayForMod<ShipType>(mod);

      foreach (ShipType shipType in validShipTypes)
      {
        Ships[shipType] = null;
      }
    }

    private void InitializeTankDictionary(string mod)
    {
      Tanks = new Dictionary<TankType, Tank?>();
      TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(mod);

      foreach (TankType tankType in validTankTypes)
      {
        Tanks[tankType] = null;
      }
    }

    public void AddShip(Ship ship)
    {
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      ShipType[] validShipTypes = EnumHelper.GetEnumTypeArrayForMod<ShipType>(settings.CurrentMod.Short);

      if (validShipTypes.Contains(ship.Type))
      {
        Ships[ship.Type] = ship;
      }
    }

    public void AddTank(Tank tank)
    {
      Settings settings = ServiceCollectionExtensions.GetService<Settings>();
      TankType[] validTankTypes = EnumHelper.GetEnumTypeArrayForMod<TankType>(settings.CurrentMod.Short);

      if (validTankTypes.Contains(tank.Type))
      {
        Tanks[tank.Type] = tank;
      }
    }

    public Tank GetTankByType(TankType tankType)
    {
      return Tanks[tankType];
    }

    public Ship GetShipByType(ShipType shipType)
    {
      return Ships[shipType];
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
}