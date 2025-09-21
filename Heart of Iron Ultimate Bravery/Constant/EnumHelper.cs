using System;
using System.Linq;

namespace Heart_of_Iron_Ultimate_Bravery.Constant
{
    public static class EnumHelper
    {
        public static T[]? GetEnumTypeArrayForMod<T>(string modName) where T : Enum
        {
            var enumType = typeof(T);
            
            return enumType.Name switch
            {
                nameof(ShipType) => GetShipTypesForMod(modName) as T[],
                nameof(TankType) => GetTankTypesForMod(modName) as T[],
                nameof(PlaneType) => GetPlaneTypesForMod(modName) as T[],
                nameof(DivisionType) => GetDivisionTypesForMod(modName) as T[],
                _ => Enum.GetValues(enumType).Cast<T>().ToArray()
            };
        }

        public static T[]? GetEnumVersionArrayForMod<T>(string modName) where T : Enum
        {
            var enumType = typeof(T);
            
            return enumType.Name switch
            {
                // nameof(ShipType) => GetShipTypesForMod(modName) as T[],
                nameof(TankVersion) => GetTankVersionsForMod(modName) as T[],
                // nameof(PlaneType) => GetPlaneTypesForMod(modName) as T[],
                // nameof(DivisionType) => GetDivisionTypesForMod(modName) as T[],
                _ => Enum.GetValues(enumType).Cast<T>().ToArray()
            };
        }

        private static ShipType[] GetShipTypesForMod(string modName)
        {
            return modName.ToLower() switch
            {
                "vanilla" => ModConstants.ShipTypes.Vanilla,
                // "kaiserreich" => ModConstants.ShipTypes.Kaiserreich,
                // "road56" => ModConstants.ShipTypes.Road56,
                _ => ModConstants.ShipTypes.Vanilla // Default fallback
            };
        }

        private static TankType[] GetTankTypesForMod(string modName)
        {
            return modName.ToLower() switch
            {
                "vanilla" => ModConstants.TankTypes.Vanilla,
                // "kaiserreich" =>,
                // "road56" =>
                //"millenniumdawn" =>,
                _ => ModConstants.TankTypes.Vanilla
            };
        }

        private static TankVersion[] GetTankVersionsForMod(string modName)
        {
            return modName.ToLower() switch
            {
                "vanilla" => ModConstants.TankVersions.Vanilla,
                // "kaiserreich" =>,
                // "road56" =>
                //"millenniumdawn" =>,
                _ => ModConstants.TankVersions.Vanilla
            };
        }

        private static TurretType[] GetTurretTypesForMod(string modName)
        {
            return modName.ToLower() switch
            {
                "vanilla" => ModConstants.TurretTypes.Vanilla,
                // "kaiserreich" =>
                // "rod56" =>
                // "millenniumdawn" =>
                _ => ModConstants.TurretTypes.Vanilla
            };
        }
        
        private static PlaneType[] GetPlaneTypesForMod(string modName)
        {
            return modName.ToLower() switch
            {
                "vanilla" => ModConstants.PlaneTypes.Vanilla,
                // "kaiserreich" => ModConstants.PlaneTypes.Kaiserreich,
                // "road56" => ModConstants.PlaneTypes.Road56,
                _ => ModConstants.PlaneTypes.Vanilla
            };
        }

        private static DivisionType[] GetDivisionTypesForMod(string modName)
        {
            return modName.ToLower() switch
            {
                "vanilla" => ModConstants.DivisionTypes.Vanilla,
                // "kaiserreich" => ModConstants.DivisionTypes.Kaiserreich,
                // "road56" => ModConstants.DivisionTypes.Road56,
                _ => ModConstants.DivisionTypes.Vanilla
            };
        }

        // Helper method to check if a specific enum value is valid for a mod
        public static bool IsValidForMod<T>(string modName, T enumValue) where T : Enum
        {
            var validEnums = GetEnumTypeArrayForMod<T>(modName);
            return validEnums.Contains(enumValue);
        }
    }
}