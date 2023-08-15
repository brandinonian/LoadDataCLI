namespace LoadDataCLI {
    public class SelectCustomLoad {
        public static CustomLoadModel Select(List<CustomLoadModel> data) {

            // start console output
            Console.WriteLine("Console Loads");

            // select the cartridge
            string cartridgeName = SelectCartridge(data);

            // filter list by cartridge
            data = CustomLoadFilters.FilterByCartridge(data, cartridgeName);

            // select the bullet
            string bulletString = SelectBulletString(data);

            // filter list by bullet
            data = CustomLoadFilters.FilterByBulletString(data, bulletString);

            // select the powder
            string powderString = SelectPowderString(data);

            // filter list by powder
            data = CustomLoadFilters.FilterByPowderString(data, powderString);

            // store the selected load in a variable
            CustomLoadModel result = SelectLoad(data);

            // return the selected load
            return result;
        }

        // prompt user to select a cartridge, return a string
        private static string SelectCartridge(List<CustomLoadModel> data) {

            // variable to hold results
            string result;
            int userSelection = 0;

            // get the list of cartridges
            List<string> cartridgeList = CustomLoadQueries.GetCartridgeList(data);

            // display list
            Console.WriteLine();
            for(int i = 0; i < cartridgeList.Count; i++) {
                Console.WriteLine($"{i + 1}: {cartridgeList[i]}");
            }

            // ask the user to make a selection
            Console.Write("\nSelect the cartridge: ");

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

        // prompt user to select a bullet, return a string
        private static string SelectBulletString(List<CustomLoadModel> data) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> bulletStringList = CustomLoadQueries.GetBulletStringList(data);

            // display list
            Console.WriteLine();
            for(int i = 0; i < bulletStringList.Count; i++) { 
                Console.WriteLine($"{i + 1}: {bulletStringList[i]}");
            }

            // ask user to make a selection
            Console.Write("\nSelect a bullet: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = bulletStringList[userSelection - 1];

            // return selection
            return result;
        }

        // prompt user to select a powder
        private static string SelectPowderString(List<CustomLoadModel> data) {

            // variables to hold results
            string result;
            int userSelection = 0;

            // get list
            List<string> powderStringList = CustomLoadQueries.GetPowderStringList(data);

            // display list
            Console.WriteLine();
            for(int i = 0; i < powderStringList.Count; i++) { 
                Console.WriteLine($"{i + 1}: {powderStringList[i]}");
            }

            // ask user to make a selection
            Console.Write("\nSelect a powder: ");

            // capture user input
            try {
                userSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // match selection to list
            result = powderStringList[userSelection - 1];

            // return selection
            return result;
        }

        // prompt user to select a load
        public static CustomLoadModel SelectLoad(List<CustomLoadModel> data) {

            // variables to hold results
            CustomLoadModel result;
            int userSelection = 0;

            // display the list of loads
            Console.WriteLine();
            for (int i = 0; i < data.Count; i++) {
                Console.WriteLine($"{i + 1}: {data[i].ShortString()}");
            }

            // ask user to select a load
            Console.Write("\nSelect a load: ");

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

