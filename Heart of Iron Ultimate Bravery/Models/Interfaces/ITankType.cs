using System;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

public interface ITankType<TankType>
where TankType : Enum
{
    public TankType Type { get; set;  }
}