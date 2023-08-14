using System;
namespace LoadDataCLI.CustomLoads
{
    public class CustomLoadQueries
    {
        // get list of cartridges
        public static List<string> GetCartridgeList(List<CustomLoadModel> data) {

            // list to hold results
            List<string> result = new();

            // get all loads grouped by cartridge
            var query =
                from load in data
                group load by load.CartridgeName into gr
                select gr;

            // add each item to the list using the Key
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return the list of cartridges
            return result; 
        }

        // get list of bullet strings
        public static List<string> GetBulletStringList(List<CustomLoadModel> data) {

            // list to hold results
            List<string> result = new();

            // query
            var query =
                from load in data
                group load by load.BulletString into gr
                select gr;

            // populate list
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return list
            return result;
        }

        // get list of powders
        public static List<string> GetPowderStringList(List<CustomLoadModel> data) {

            // list to hold results
            List<string> result = new();

            // query
            var query =
                from load in data
                group load by load.PowderString into gr
                select gr;

            // populate list
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return list
            return result;
        }
    }
}

