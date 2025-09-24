using System;
using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Armor;

public class VanillaArmor : BaseArmor
{
    public enum ArmorType
    {
        Cast,
        Riveted,
        Welded
    }

    public static readonly List<ArmorType> ArmorTypes = new()
    {
        ArmorType.Cast,
        ArmorType.Riveted,
        ArmorType.Welded
    };

    public ArmorType Type;

    public VanillaArmor()
    {
        Random rnd = new Random();
        Type = ArmorTypes[rnd.Next(0, ArmorTypes.Count)];
    }    
    
    public override void InitializeModSpecificProperties() {}

    public override string GetModIdentifier() => "vanilla";

}