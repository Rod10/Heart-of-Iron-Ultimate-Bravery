// File: Constants/ModConstants.cs
// Define which enums are available for each mod

namespace Heart_of_Iron_Ultimate_Bravery.Constant
{
    public static class ModConstants
    {
        // Ship types by mod
        public static class ShipTypes
        {
            public static readonly ShipType[] Vanilla = 
            {
                ShipType.Destroyer,
                ShipType.Cruiser,
                ShipType.Battleship,
                ShipType.Carrier,
                ShipType.Submarine
            };

            public static readonly ShipType[] Kaiserreich = 
            {
                ShipType.Destroyer,
                ShipType.Cruiser,
                ShipType.Battleship,
                ShipType.Carrier,
                ShipType.Dreadnought,
                ShipType.BattleCruiser,
                ShipType.Submarine
            };

            public static readonly ShipType[] Road56 = 
            {
                ShipType.Destroyer,
                ShipType.Cruiser,
                ShipType.Battleship,
                ShipType.Carrier,
                ShipType.SuperCarrier,
                ShipType.Submarine,
                ShipType.BattleCruiser
            };
        }

        // Tank types by mod
        public static class TankTypes
        {
            public static readonly TankType[] Vanilla = 
            {
                TankType.LightTank,
                TankType.MediumTank,
                TankType.HeavyTank,
                TankType.TankDestroyer
            };

            public static readonly TankType[] Kaiserreich = 
            {
                TankType.LightTank,
                TankType.MediumTank,
                TankType.HeavyTank,
                TankType.SuperHeavyTank,
                TankType.TankDestroyer
            };

            public static readonly TankType[] Road56 = 
            {
                TankType.LightTank,
                TankType.MediumTank,
                TankType.HeavyTank,
                TankType.ModernTank,
                TankType.TankDestroyer
            };
        }

        // Plane types by mod
        public static class PlaneTypes
        {
            public static readonly PlaneType[] Vanilla = 
            {
                PlaneType.Fighter,
                PlaneType.Bomber,
                PlaneType.CAS,
                PlaneType.NavalBomber
            };

            public static readonly PlaneType[] Kaiserreich = 
            {
                PlaneType.Fighter,
                PlaneType.Bomber,
                PlaneType.CAS,
                PlaneType.NavalBomber
            };

            public static readonly PlaneType[] Road56 = 
            {
                PlaneType.Fighter,
                PlaneType.Bomber,
                PlaneType.CAS,
                PlaneType.NavalBomber,
                PlaneType.StrategicBomber,
                PlaneType.JetFighter
            };
        }

        // Division types by mod
        public static class DivisionTypes
        {
            public static readonly DivisionType[] Vanilla = 
            {
                DivisionType.Infantry,
                DivisionType.Motorized,
                DivisionType.Mechanized,
                DivisionType.Armor
            };

            public static readonly DivisionType[] Kaiserreich = 
            {
                DivisionType.Infantry,
                DivisionType.Motorized,
                DivisionType.Mechanized,
                DivisionType.Armor,
                DivisionType.Marines
            };

            public static readonly DivisionType[] Road56 = 
            {
                DivisionType.Infantry,
                DivisionType.Motorized,
                DivisionType.Mechanized,
                DivisionType.Armor,
                DivisionType.Marines,
                DivisionType.Paratroopers,
                DivisionType.MountainTroops
            };
        }
    }
}