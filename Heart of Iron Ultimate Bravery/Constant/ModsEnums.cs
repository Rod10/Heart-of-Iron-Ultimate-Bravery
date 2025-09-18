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
        // Mod-specific additions
        Dreadnought,      // Kaiserreich
        SuperCarrier,     // Road to 56
        Submarine,
        BattleCruiser
    }

    public enum TankType
    {
        LightTank,
        MediumTank,
        HeavyTank,
        // Mod-specific additions
        SuperHeavyTank,   // Kaiserreich
        ModernTank,       // Road to 56
        TankDestroyer
    }

    public enum PlaneType
    {
        Fighter,
        Bomber,
        CAS,
        NavalBomber,
        // Mod-specific additions
        StrategicBomber,  // Road to 56
        JetFighter        // Road to 56
    }

    public enum DivisionType
    {
        Infantry,
        Motorized,
        Mechanized,
        Armor,
        // Mod-specific additions
        Marines,
        Paratroopers,
        MountainTroops
    }
}