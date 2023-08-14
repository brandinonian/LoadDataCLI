namespace LoadDataCLI {
    public class CreateCustomLoad {
        public static CustomLoadModel? Create() {

            // to store the created load
            CustomLoadModel newLoad;

            // in case input can't be parsed
            bool repeat = true;

            //
            // user input for load parameters
            //

            // input cartridge
            string? cartridgeName;
            do {
                Console.WriteLine("Enter the cartridge: ");
                cartridgeName = Console.ReadLine();
            } while(cartridgeName == string.Empty);

            // input overall length (double)
            double overallLength = 0;

            do {

                // set repeat
                repeat = true;

                // console output
                Console.Write("Enter the overall length: ");

                // try parsing input, catch exceptions
                try {
                    overallLength = double.Parse(Console.ReadLine());

                    // don't repeat on valid input
                    repeat = false;
                }
                catch(Exception ex) {

                    // print to console
                    Console.WriteLine(ex.Message);
                }
            }
            while(repeat);

            // input barrel
            string? barrelName;
            do {
                Console.WriteLine("Enter the barrel: ");
                barrelName = Console.ReadLine();
            } while(barrelName == string.Empty);

            // input bullet name
            string? bulletName;
            do {
                Console.WriteLine("Enter the bullet name: ");
                bulletName = Console.ReadLine();
            } while(bulletName == string.Empty);

            // input bullet manufacturer
            string? bulletManufacturer;
            do {
                Console.WriteLine("Enter the bullet manufacturer: ");
                bulletManufacturer = Console.ReadLine();
            } while(bulletManufacturer == string.Empty);

            // input bullet weight (double), repeat on exceptions
            double bulletWeight = 0;

            do {

                // set repeat
                repeat = true;

                // console output
                Console.Write("Enter the bullet weight: ");

                // try parsing input, catch exceptions
                try {
                    bulletWeight = double.Parse(Console.ReadLine());

                    // don't repeat on valid input
                    repeat = false;
                }
                catch(Exception ex) {

                    // print to console
                    Console.WriteLine(ex.Message);
                }
            }
            while(repeat);

            // input manufacturer, repeat if null
            string? brassManufacturer;
            do {
                Console.WriteLine("Enter the brass manufacturer: ");
                brassManufacturer = Console.ReadLine();
            } while(brassManufacturer == string.Empty);

            // input brass annealing time
            double brassAnnealedTime = 0;

            do {

                // set repeat
                repeat = true;

                // console output
                Console.Write("Enter the brass annealing time (0 for none): ");

                // try parsing input, catch exceptions
                try {
                    brassAnnealedTime = double.Parse(Console.ReadLine());

                    // don't repeat on valid input
                    repeat = false;
                }
                catch(Exception ex) {

                    // print to console
                    Console.WriteLine(ex.Message);
                }
            }
            while(repeat);

            // input brass length
            double brassLength = 0;

            do {

                // set repeat
                repeat = true;

                // console output
                Console.Write("Enter the brass length: ");

                // try parsing input, catch exceptions
                try {
                    brassLength = double.Parse(Console.ReadLine());

                    // don't repeat on valid input
                    repeat = false;
                }
                catch(Exception ex) {

                    // print to console
                    Console.WriteLine(ex.Message);
                }
            }
            while(repeat);

            // input brass number of firings
            int brassNumberFirings = 0;

            do {

                // set repeat
                repeat = true;

                // console output
                Console.Write("Enter the brass number of firings: ");

                // try parsing input, catch exceptions
                try {
                    brassNumberFirings = int.Parse(Console.ReadLine());

                    // don't repeat on valid input
                    repeat = false;
                }
                catch(Exception ex) {

                    // print to console
                    Console.WriteLine(ex.Message);
                }
            }
            while(repeat);

            // input primer manufacturer
            string? primerManufacturer;
            do {
                Console.WriteLine("Enter the primer manufacturer: ");
                primerManufacturer = Console.ReadLine();
            } while(primerManufacturer == string.Empty);

            // input primer name
            string? primerName;
            do {
                Console.WriteLine("Enter the primer name: ");
                primerName = Console.ReadLine();
            } while(primerName == string.Empty);

            // input powder manufacturer
            string? powderManufacturer;
            do {
                Console.WriteLine("Enter the powder manufacturer: ");
                powderManufacturer = Console.ReadLine();
            } while(powderManufacturer == string.Empty);

            // input powder name
            string? powderName;
            do {
                Console.WriteLine("Enter the powder name: ");
                powderName = Console.ReadLine();
            } while(powderName == string.Empty);

            // populate the load model with data
            newLoad = new CustomLoadModel(cartridgeName,
                                          overallLength,
                                          barrelName,
                                          bulletName,
                                          bulletManufacturer,
                                          bulletWeight,
                                          brassManufacturer,
                                          brassAnnealedTime,
                                          brassLength,
                                          brassNumberFirings,
                                          primerManufacturer,
                                          primerName,
                                          powderManufacturer,
                                          powderName);

            // return result
            return newLoad;
        }
    }
}

