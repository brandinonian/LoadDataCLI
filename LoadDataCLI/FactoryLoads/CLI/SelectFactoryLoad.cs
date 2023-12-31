﻿namespace LoadDataCLI {

    public class SelectFactoryLoad {

        // entry point
        public static FactoryLoadModel Select(List<FactoryLoadModel> data) {

            // start console output
            Console.WriteLine("Factory Loads");

            // select the cartridge
            string cartridgeName = SelectCartridge(data);

            // filter list by cartridge
            data = FactoryLoadFilters.FilterByCartridge(data, cartridgeName);

            // select the manufacturer
            string manufacturerName = SelectManufacturer(data);

            // filter by manufacturer
            data = FactoryLoadFilters.FilterByManufacturer(data, manufacturerName);

            // select the bullet string
            string bulletString = SelectBulletString(data);

            // filter by bulletString
            data = FactoryLoadFilters.FilterByBulletString(data, bulletString);

            // store the selected load in a variable
            FactoryLoadModel result = SelectLoad(data);

            // return the selected load
            return result;

        }

        // prompt user to select a cartridge, return a string
        public static string SelectCartridge(List<FactoryLoadModel> data) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get the list of cartridges
            List<string> cartridgeList = FactoryLoadQueries.GetCartridgeList(data);

            // display list
            for (int i = 0; i < cartridgeList.Count; i++) {
                Console.WriteLine($"{i + 1}: {cartridgeList[i]}");
            }

            // ask the user to make a selection
            Console.Write("Select the cartridge: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match user input to the list of cartridges
            result = cartridgeList[userSelection - 1];

            // return the cartridge name
            return result;
        }

        // prompt user to select a manufacturer, return a string
        public static string SelectManufacturer(List<FactoryLoadModel> data) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> manufacturerList = FactoryLoadQueries.GetManufacturerList(data);

            // display list
            for (int i = 0; i < manufacturerList.Count; i++) {
                Console.WriteLine($"{i + 1}: {manufacturerList[i]}");
            }

            // ask user to make a selection
            Console.Write("Select a manufacturer: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = manufacturerList[userSelection - 1];

            // return selection
            return result;
        }

        // prompt user to select a bullet, return a string
        public static string SelectBulletString(List<FactoryLoadModel> data) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> bulletList = FactoryLoadQueries.GetBulletStringList(data);

            // display list
            for (int i = 0; i < bulletList.Count; i++) {
                Console.WriteLine($"{i + 1}: {bulletList[i]}");
            }

            // ask user to make a selection
            Console.Write("Select a bullet: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = bulletList[userSelection - 1];

            // return selection
            return result;
        }

        // prompt user to select a load
        public static FactoryLoadModel SelectLoad(List<FactoryLoadModel> data) {

            // variables to hold results
            FactoryLoadModel result;
            int userSelection = 0;

            // display the list of loads
            for (int i = 0; i < data.Count; i++) {
                Console.WriteLine($"{i + 1}: {data[i].ShortString()}");
            }

            // ask user to select a load
            Console.Write("Select a load: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = data[userSelection - 1];

            return result;
        }
    }
}

