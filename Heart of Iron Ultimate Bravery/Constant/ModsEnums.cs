// File: Enums/ModEnums.cs
// All your mod-specific enums in one place
namespace Heart_of_Iron_Ultimate_Bravery.Constant
{
    // Base enums that all mods share
    public enum ShipType
    {
        Destroyer,
        Cruiser,
        Battleship,
        Carrier,
        Submarine
    }

    public enum TankType
    {
        Light,
        Medium,
        Heavy,
        SuperHeavy,
        Modern,
        // Millennium Dawn
        MainBattleTank
    }

    public enum PlaneType
    {
        Fighter,
        CloseAirSupport,
        NavalBomber,
        TacticalBomber,
        StrategicBomber
    }

    public enum DivisionType
    {
        Infantry,
        Armor
    }

    public enum TankVersion
    {
        /* Base Game */
        InterWar,
        Basic,
        Improved,
        Advanced
        /* Base Game */
    }

    public enum TurretType
    {
        Light,
        Medium,
        Large,
        SuperHeavy,
        Modern
    }
}