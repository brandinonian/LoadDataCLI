﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI {
    public class FactoryLoadFilters {

        // filter by cartridge
        public static List<FactoryLoad> FilterByCartridge(List<FactoryLoad> data, string cartridgeName) {

            // list to hold results
            List<FactoryLoad> results = new List<FactoryLoad>();

            // filter input list
            var query = 
                from load in data
                where load.CartridgeName == cartridgeName
                select load;

            // add results to list
            foreach(var item in query)
                results.Add(item);

            // return list
            return results;
        }

        // filter by manufacturer
        public static List<FactoryLoad> FilterByManufacturer(List<FactoryLoad> data, string manufacturer) {

            // list to hold results
            List<FactoryLoad> results = new List<FactoryLoad>();

            // filter input list
            var query = 
                from load in data
                where load.Manufacturer == manufacturer
                select load;

            // add results to list
            foreach(var item in query)
                results.Add(item);

            // return list
            return results;
        }

        // filter by bullet string
        public static List<FactoryLoad> FilterByBulletString(List<FactoryLoad> data, string bulletString) {

            // list to hold results
            List<FactoryLoad> results = new List<FactoryLoad>();

            // filter input list
            var query = 
                from load in data
                where load.BulletString == bulletString
                select load;

            // add results to list
            foreach(var item in query)
                results.Add(item);

            // return list
            return results;
        }
    }
}
