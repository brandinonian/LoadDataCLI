namespace LoadDataCLI.CustomLoads {
    public class CustomLoadSelection {
        // TODO: Break this apart into smaller chunks before adding the complete list of params


        // entry point
        public void Run() {
            Console.WriteLine("Custom Loads");

            // select the cartridge
            string cartridgeName = SelectCartridgeName();

            // select the bullet manufacturer
            string bulletManufacturer = SelectBulletManufacturer(cartridgeName);

            // select the bullet weight
            double bulletWeight = SelectBulletWeight(cartridgeName, bulletManufacturer);

            // select the bullet name
            string bulletName = SelectBulletName(cartridgeName, bulletManufacturer, bulletWeight);

            // select the powder
            string powderName = SelectPowderName(cartridgeName, bulletManufacturer, bulletWeight, bulletName);

            // select the load
            CustomLoad customLoad = GetLoad(cartridgeName, bulletManufacturer, bulletWeight, bulletName, powderName);

            // display the load
            // TODO
            
        }

        // TODO: get load data
        List<CustomLoad> customLoads = new List<CustomLoad>();


        //
        // cartridge selection
        //

        // prompt the user to select a cartridge, return the name as a string
        public string SelectCartridgeName() {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get the list of cartridges
            List<string> cartridgeList = GetCartridgeNameList();

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

        // retrieve list of cartridges
        public List<string> GetCartridgeNameList() {

            // list to hold results
            List<string> result = new List<string>();

            // get all loads grouped by cartridge
            var query =
                from load in customLoads
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
        // bullet manufacturer selection
        //

        // prompt user to select a bullet manufacturer, return a string
        public string SelectBulletManufacturer(string cartridgeName) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list of bullet manufacturers filtered by cartridgeName
            List<string> bulletManufacturerList = GetBulletManufacturerList(cartridgeName);

            // display the list of bullet manufacturers
            for (int i = 0; i < bulletManufacturerList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {bulletManufacturerList[i]} gr");
            }

            // ask the user to make a selection
            Console.Write("Select the bullet manufacturer: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match user input to the list of bullet manufacturers
            result = bulletManufacturerList[userSelection - 1];

            // return the bullet manufacturer
            return result;
        }

        // retreive list of bullet manufacturers
        public List<string> GetBulletManufacturerList(string cartridgeName) {

            // list to hold results
            List<string> result = new List<string>();

            // get all loads, filtered by cartridge, grouped by bullet manufacturer
            var query =
                from load in customLoads
                where load.CartridgeName == cartridgeName
                group load by load.BulletManufacturer into gr
                select gr;

            // add each item to the list using the Key
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return the list of bullet weights
            return result;
        }


        //
        // bullet weight selection
        //

        // prompt the user to select a bullet weight, return a double
        public double SelectBulletWeight(string cartridgeName, string bulletManufacturer) {

            // variables to hold results
            double result;
            int userSelection = 0;

            // get list of bullets filtered by cartridgeName
            List<double> bulletWeightList = GetBulletWeightList(cartridgeName, bulletManufacturer);

            // display the list of bullet weights
            for (int i = 0; i < bulletWeightList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {bulletWeightList[i]} gr");
            }

            // ask the user to make a selection
            Console.Write("Select the bullet weight: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match user input to the list of bullets
            result = bulletWeightList[userSelection - 1];

            // return the bullet weight
            return result;
        }

        // retrieve list of bullet weights
        public List<double> GetBulletWeightList(string cartridgeName, string bulletManufacturer) {

            // list to hold results
            List<double> result = new List<double>();

            // get all loads, filtered by cartridge, grouped by bullet
            var query =
                from load in customLoads
                where load.CartridgeName == cartridgeName
                where load.BulletManufacturer == bulletManufacturer
                group load by load.BulletWeight into gr
                select gr;

            // add each item to the list using the Key
            foreach (var item in query) {

                // do not include null values
                if (item.Key != null)
                    result.Add((double)item.Key);
            }

            // return the list of bullet weights
            return result;
        }


        //
        // bullet name selection
        //

        // prompt the user to select a bullet name, return a string
        public string SelectBulletName(string cartridgeName, string bulletManufacturer, double bulletWeight) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get the list of bullets filtered by cartridge and weight
            List<string> bulletNameList = GetBulletNameList(cartridgeName, bulletManufacturer, bulletWeight);

            // display the list of bullet names
            for (int i = 0; i < bulletNameList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {bulletNameList[i]}");
            }

            // ask the user to make a selection
            Console.Write("Select the bullet name: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match user input to the list
            result = bulletNameList[userSelection - 1];

            // return the bullet name
            return result;
        }

        // retrieve list of bullet names
        public List<string> GetBulletNameList(string cartridgeName, string bulletManufacturer, double bulletWeight) {

            // list to hold results
            List<string> result = new List<string>();

            // get all loads, filtered by cartridge and bullet weight, grouped by bullet name
            var query =
                from load in customLoads
                where load.CartridgeName == cartridgeName
                where load.BulletManufacturer == bulletManufacturer
                where load.BulletWeight == bulletWeight
                group load by load.BulletName into gr
                select gr;

            // add each item to the list using the Key
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return the list of bullet names
            return result;
        }


        //
        // powder selection
        //

        // prompt the user to select a powder and return as a string
        public string SelectPowderName(string cartridgeName, string bulletManufacturer, double bulletWeight, string bulletName) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get the list of powders filtered by cartridge and bullet
            List<string> powderList = GetPowderNameList(cartridgeName, bulletManufacturer, bulletWeight, bulletName);

            // display the list of powder names
            for (int i = 0; i < powderList.Count; i++) {
                Console.WriteLine($"[{i + 1}]: {powderList[i]}");
            }

            // ask the user to make a selection
            Console.Write("Select a powder: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match user input to the list
            result = powderList[userSelection - 1];

            // return the powder name
            return result;
        }

        // retrieve list of powder names
        public List<string> GetPowderNameList(string cartridgeName, string bulletManufacturer, double bulletWeight, string bulletName) {

            // list to hold results
            List<string> result = new List<string>();

            // get all loads, filtered by cartridge and bullet, grouped by powder
            var query =
                from load in customLoads
                where load.CartridgeName == cartridgeName
                where load.BulletManufacturer == bulletManufacturer
                where load.BulletWeight == bulletWeight
                where load.BulletName == bulletName
                group load by load.PowderName into gr
                select gr;

            // add each item to the list using the key
            foreach (var item in query) {
                result.Add(item.Key);
            }

            // return the list of powder names
            return result;
        }


        //
        // final load selection
        //

        // select correct load using user selections
        public CustomLoad GetLoad(string cartridgeName, string bulletManufacturer, double bulletWeight, string bulletName, string powderName) {

            // variable to hold result
            CustomLoad result;

            // TODO: test this portion carefully
            // query list using user selections
            var query =
                from load in customLoads
                where load.CartridgeName == cartridgeName
                where load.BulletManufacturer == bulletManufacturer
                where load.BulletWeight == bulletWeight
                where load.BulletName == bulletName
                where load.PowderName == powderName
                select load;

            // store query in result
            result = (CustomLoad)query;

            // return the correct load
            return result;
        }
    }
}
