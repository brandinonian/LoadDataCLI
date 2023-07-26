namespace LoadDataCLI {

    public class FactoryLoadSelector {
        // entry point
        public static FactoryLoad Init(List<FactoryLoad> data) {
            Console.WriteLine("Factory Loads");

            // select the cartridge
            string cartridgeName = SelectCartridge(data);

            // select the manufacturer
            string manufacturerName = SelectManufacturer(data, cartridgeName);

            // TODO: would be nice to combine name and weight, possibly parse the weight to a string?
            // then select the bullet weight
            double bulletWeight = SelectBulletWeight(data, cartridgeName, manufacturerName);

            // then select the bullet name
            string bulletName = SelectBulletName(data, cartridgeName, manufacturerName, bulletWeight);

            // store the selected load in a variable
            FactoryLoad result;

            // catch null exceptions
            try {
                result = GetFilteredLoad(data, cartridgeName, manufacturerName, bulletWeight, bulletName);
            }
            catch (Exception) {
                throw new Exception("No load found...");
            }

            // return the selected load
            return result;
            
        }


        //
        // cartridge selection
        //

        // prompt the user to select a cartridge, return the name as a string
        public static string SelectCartridge(List<FactoryLoad> data) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get the list of cartridges
            List<string> cartridgeList = GetCartridgeList(data);

            // display the numbered list of cartridges
            // check for null values and do not include
            for(int i = 0; i < cartridgeList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {cartridgeList[i]}");
            }

            // ask the user to make a selection
            Console.Write("Select the cartridge: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            // match user input to the list of cartridges
            result = cartridgeList[userSelection - 1];

            // return the cartridge name
            return result;
        }


        public static List<string> GetCartridgeList(List<FactoryLoad> data) {

            // list to hold results
            List<string> result = new List<string>();

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


        //
        // manufacturer selection
        //

        // prompt the user to select a manufacturer, return a string
        public static string SelectManufacturer(List<FactoryLoad> data, string cartridgeName) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> manufacturerList = GetManufacturerList(data, cartridgeName);

            // display list
            for(int i = 0; i < manufacturerList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {manufacturerList[i]}");
            }

            // ask user to make a selection
            Console.Write("Select a manufacturer: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = manufacturerList[userSelection - 1];

            // return selection
            return result;
        }

        // retrieve list of manufacturers
        public static List<string> GetManufacturerList(List<FactoryLoad> data, string cartridgeName) {

            // list to hold results
            List<string> result = new List<string>();

            // get all loads, filter by cartridge, group by manufacturer
            var query =
                from load in data
                where load.CartridgeName == cartridgeName
                group load by load.Manufacturer into gr
                select gr;

            // add each item to the list using the key
            foreach(var item in query) {
                result.Add(item.Key);
            }

            // return the list of manufacturers
            return result;
        }


        //
        // bullet weight selection
        //

        // prompt the user to select a bullet weight, return a double
        public static double SelectBulletWeight(List<FactoryLoad> data, string cartridgeName, string manufacturerName) {

            // variables to hold results
            double result;
            int userSelection = 0;

            // get list
            List<double> bulletWeightList = GetBulletWeightList(data, cartridgeName, manufacturerName);

            // display list
            for(int i = 0; i < bulletWeightList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {bulletWeightList[i]} gr");
            }

            // ask user to make a selection
            Console.Write("Select the bullet weight: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = bulletWeightList[userSelection - 1];

            // return selection
            return result;
        }

        // retrieve list of bullet weights
        public static List<double> GetBulletWeightList(List<FactoryLoad> data, string cartridgeName, string manufacturerName) {

            // list to hold results
            List<double> result = new List<double>();

            // query
            var query =
                from load in data
                where load.CartridgeName == cartridgeName
                where load.Manufacturer == manufacturerName
                group load by load.BulletWeight into gr
                select gr;

            // populate list
            foreach(var item in query) {
                result.Add((double)item.Key);
            }

            // return list
            return result;
        }


        //
        // bullet name selection
        //

        // prompt the user to select a bullet name, return a string
        public static string SelectBulletName(List<FactoryLoad> data, string cartridgeName, string manufacturerName, double bulletWeight) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> bulletNameList = GetBulletNameList(data, cartridgeName, manufacturerName, bulletWeight);

            // display list
            for(int i = 0; i < bulletNameList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {bulletNameList[i]}");
            }

            // ask user to make a selection
            Console.Write("Select the bullet name: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = bulletNameList[userSelection - 1];

            // return selection
            return result;
        }

        // retrieve list of bullet names
        public static List<string> GetBulletNameList(List<FactoryLoad> data, string cartridgeName, string manufacturerName, double bulletWeight) {

            // list to hold results
            List<string> result = new List<string>();

            // query
            var query =
                from load in data
                where load.CartridgeName == cartridgeName
                where load.Manufacturer == manufacturerName
                where load.BulletWeight == bulletWeight
                group load by load.BulletName into gr
                select gr;

            // populate list
            foreach(var item in query) {
                result.Add(item.Key);
            }

            // return list
            return result;
        }


        //
        // get individual load using filters
        //
        public static FactoryLoad GetFilteredLoad(List<FactoryLoad> data, string cartridgeName, string manufacturerName, double bulletWeight, string bulletName) {

            // variable to store result
            FactoryLoad? result = null;

            // query list with filters
            var query =
                from load in data
                where load.CartridgeName == cartridgeName
                where load.Manufacturer == manufacturerName
                where load.BulletWeight == bulletWeight
                where load.BulletName == bulletName
                select load;

            // assign query result to variable
            foreach( var item in query) {
                result = item;
            }

            // return result if not null
            if(result == null)
                throw new Exception("null");
            else
                return result;
        }
    }
}

