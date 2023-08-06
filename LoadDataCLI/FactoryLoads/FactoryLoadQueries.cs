using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI {
    public class FactoryLoadQueries {

        // get list of cartirdges
        public static List<string> GetCartridgeList(List<FactoryLoadModel> data) {

            // list to hold results
            List<string> result = new();

            // get all loads grouped by cartridge
            var query =
                from load in data
                group load by load.CartridgeName into gr
                select gr;

            // add each item to the list using the Key
            foreach(var item in query) {
                result.Add(item.Key);
            }

            // return the list of cartridges
            return result;

        }

         // retrieve list of manufacturers
        public static List<string> GetManufacturerList(List<FactoryLoadModel> data) {

            // list to hold results
            List<string> result = new();

            // get all loads, filter by cartridge, group by manufacturer
            var query =
                from load in data
                group load by load.ManufacturerName into gr
                select gr;

            // add each item to the list using the key
            foreach(var item in query) {
                result.Add(item.Key);
            }

            // return the list of manufacturers
            return result;
        }

        // retrieve list of bullet weights
        public static List<string> GetBulletStringList(List<FactoryLoadModel> data) {

            // list to hold results
            List<string> result = new();

            // query
            var query =
                from load in data
                group load by load.BulletString into gr
                select gr;

            // populate list
            foreach(var item in query) {
                result.Add(item.Key);
            }

            // return list
            return result;
        }
        
        // retrieve list of bullet weights
        public static List<double> GetBulletWeightList(List<FactoryLoadModel> data) {

            // list to hold results
            List<double> result = new();

            // query
            var query =
                from load in data
                group load by load.BulletWeight into gr
                select gr;

            // populate list
            foreach(var item in query) {
                result.Add((double)item.Key);
            }

            // return list
            return result;
        }
        
        // retrieve list of bullet names
        public static List<string> GetBulletNameList(List<FactoryLoadModel> data) {

            // list to hold results
            List<string> result = new();

            // query
            var query =
                from load in data
                group load by load.BulletName into gr
                select gr;

            // populate list
            foreach(var item in query) {
                result.Add(item.Key);
            }

            // return list
            return result;
        }

    }
}
