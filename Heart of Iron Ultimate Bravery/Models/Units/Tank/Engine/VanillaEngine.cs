using System;
using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Engine;

public class VanillaEngine : BaseEngine
{
    public enum EngineType
    {
        Diesel,
        Gas,
        Gasoline,
        PetrolElectric,
    }

    public static readonly List<EngineType> EngineTypes = new()
    {
        EngineType.Diesel,
        EngineType.Gas,
        EngineType.Gasoline,
        EngineType.PetrolElectric,
    };

    public EngineType Type;

    public VanillaEngine()
    {
        Random rnd = new Random();
        Type = EngineTypes[rnd.Next(0, EngineTypes.Count)];
    }    
    
    public override void InitializeModSpecificProperties() {}

    public override string GetModIdentifier() => "vanilla";

}