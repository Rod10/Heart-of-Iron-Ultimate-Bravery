using System;
using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Units.Tank.Suspension;

public class VanillaSuspension : BaseSuspension
{
    public enum SuspensionType
    {
        Bogie,
        Christie,
        Interleaved,
        Torsion,
        HalfTrack,
        Wheeled,
    }

    public List<SuspensionType> SuspensionTypes { get; set; } = new()
    {
        SuspensionType.Bogie,
        SuspensionType.Christie,
        SuspensionType.Interleaved,
        SuspensionType.Torsion,
        SuspensionType.HalfTrack,
        SuspensionType.Wheeled,
    };
    
    public SuspensionType Type;

    public VanillaSuspension()
    {
        Random rnd = new Random();
        Type = SuspensionTypes[rnd.Next(0, SuspensionTypes.Count)];
    }
    
    public override void InitializeModSpecificProperties() {}

    public override string GetModIdentifier() => "vanilla";
}