using ReloadingClasses;

namespace LoadDataCLI.FactoryLoads {

    public class FactoryLoadSelection {
        // entry point
        // TODO: accept a list as an argument and return a load/list
        public void Run() {
            Console.WriteLine("Factory Loads");

            // select the cartridge
            string cartridgeName = SelectCartridge();

            // select the manufacturer
            string manufacturerName = SelectManufacturer(cartridgeName);

            // TODO: would be nice to combine name and weight, possibly parse the weight to a string?
            // then select the bullet weight
            double bulletWeight = SelectBulletWeight(cartridgeName, manufacturerName);

            // then select the bullet name
            string bulletName = SelectBulletName(cartridgeName, manufacturerName, bulletWeight);

            // TODO display the load information
        }

        // TODO get load data
        List<FactoryLoad> factoryLoads = new List<FactoryLoad>();


        //
        // cartridge selection
        //

        // prompt the user to select a cartridge, return the name as a string
        public string SelectCartridge() {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get the list of cartridges
            List<string> cartridgeList = GetCartridgeList();

            // display the numbered list of cartridges
            // check for null values and do not include
            for (int i = 0; i < cartridgeList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {cartridgeList[i]}");
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


        public List<string> GetCartridgeList() {

            // list to hold results
            List<string> result = new List<string>();

            // get all loads grouped by cartridge
            var query =
                from load in factoryLoads
                group load by load.CartridgeName into gr
                select gr;

            // add each item to the list using the Key
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return the list of cartridges
            return result;

        }


        //
        // manufacturer selection
        //

        // prompt the user to select a manufacturer, return a string
        public string SelectManufacturer(string cartridgeName) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> manufacturerList = GetManufacturerList(cartridgeName);

            // display list
            for (int i = 0; i < manufacturerList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {manufacturerList[i]}");
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
            result = manufacturerList[userSelection];

            // return selection
            return result;
        }

        // retrieve list of manufacturers
        public List<string> GetManufacturerList(string cartridgeName) {

            // list to hold results
            List<string> result = new List<string>();

            // get all loads, filter by cartridge, group by manufacturer
            var query =
                from load in factoryLoads
                where load.CartridgeName == cartridgeName
                group load by load.Manufacturer into gr
                select gr;

            // add each item to the list using the key
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return the list of manufacturers
            return result;
        }


        //
        // bullet weight selection
        //

        // prompt the user to select a bullet weight, return a double
        public double SelectBulletWeight(string cartridgeName, string manufacturerName) {

            // variables to hold results
            double result;
            int userSelection = 0;

            // get list
            List<double> bulletWeightList = GetBulletWeightList(cartridgeName, manufacturerName);

            // display list
            for (int i = 0; i < bulletWeightList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {bulletWeightList[i]} gr");
            }

            // ask user to make a selection
            Console.Write("Select the bullet weight: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = bulletWeightList[userSelection - 1];

            // return selection
            return result;
        }

        // retrieve list of bullet weights
        public List<double> GetBulletWeightList(string cartridgeName, string manufacturerName) {

            // list to hold results
            List<double> result = new List<double>();

            // query
            var query =
                from load in factoryLoads
                where load.CartridgeName == cartridgeName
                where load.Manufacturer == manufacturerName
                group load by load.BulletWeight into gr
                select gr;

            // populate list
            foreach (var item in query) {

                // do not include null values
                if (item.Key != null)
                    result.Add((double)item.Key);
            }

            // return list
            return result;
        }


        //
        // bullet name selection
        //

        // prompt the user to select a bullet name, return a string
        public string SelectBulletName(string cartridgeName, string manufacturerName, double bulletWeight) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> bulletNameList = GetBulletNameList(cartridgeName, manufacturerName, bulletWeight);

            // display list
            for (int i = 0; i < bulletNameList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {bulletNameList[i]}");
            }

            // ask user to make a selection
            Console.Write("Select the bullet name: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = bulletNameList[userSelection - 1];

            // return selection
            return result;
        }

        // retrieve list of bullet names
        public List<string> GetBulletNameList(string cartridgeName, string manufacturerName, double bulletWeight) {

            // list to hold results
            List<string> result = new List<string>();

            // query
            var query =
                from load in factoryLoads
                where load.CartridgeName == cartridgeName
                where load.Manufacturer == manufacturerName
                where load.BulletWeight == bulletWeight
                group load by load.BulletName into gr
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

