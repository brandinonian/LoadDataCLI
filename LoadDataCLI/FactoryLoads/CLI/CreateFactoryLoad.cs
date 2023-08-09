namespace LoadDataCLI {
    public class CreateFactoryLoad {

        public static FactoryLoadModel? Create() {

            // to store the created load
            FactoryLoadModel newLoad;

            //
            // user input for load parameters
            //
            // input cartridge, repeat if null
            string? cartridgeName;
            do {
                Console.WriteLine("Enter the cartridge: ");
                cartridgeName = Console.ReadLine();
            } while (cartridgeName == string.Empty);

            // input manufacturer, repeat if null
            string? manufacturer;
            do {
                Console.WriteLine("Enter the manufacturer: ");
                manufacturer = Console.ReadLine();
            } while (manufacturer == string.Empty);

            // input bullet name, repeat if null
            string? bulletName;
            do {
                Console.WriteLine("Enter the bullet name: ");
                bulletName = Console.ReadLine();
            } while (bulletName == string.Empty);

            // input bullet weight (double), repeat on exceptions
            double bulletWeight;

            // in case input can't be parsed
            bool repeat = true;

            while (repeat) {
                Console.Write("Enter the bullet weight: ");

                // catch exceptions
                try {
                    bulletWeight = double.Parse(Console.ReadLine());
                    repeat = false;

                    // populate the load model with data
                    newLoad = new FactoryLoadModel(cartridgeName, manufacturer, bulletName, bulletWeight);

                    // return the completed load
                    return newLoad;
                }
                catch (Exception ex) {

                    // repeat on exceptions
                    repeat = true;

                    // print to console
                    Console.WriteLine(ex.Message);
                }
            }

            // exit without valid data
            return null;
        }
    }
}
