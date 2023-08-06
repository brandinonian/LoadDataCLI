using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI {
    public class CreateFactoryLoad {

        public static FactoryLoadModel? Create() {

            // to store the created load
            FactoryLoadModel newLoad;

            //
            // user input for load parameters
            //
            // input cartridge, repeat if null
            string? cartridgeName = null;

            do {
                Console.WriteLine("Enter the cartridge: ");
                cartridgeName = Console.ReadLine();
            } while(cartridgeName != null);

            // input manufacturer, repeat if null
            string? manufacturer = null;

            do {
                Console.WriteLine("Enter the manufacturer: ");
                manufacturer = Console.ReadLine();
            } while(manufacturer != null);

            // input bullet name, repeat if null
            string? bulletName = null;

            do {
                Console.WriteLine("Enter the bullet name: ");
                bulletName = Console.ReadLine();
            } while(bulletName != null);

            // input bullet weight (double), repeat on exceptions
            double bulletWeight;
            bool repeat = true;

            while(!repeat) {
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
                catch(Exception ex) {
                    repeat = false;
                    Console.WriteLine(ex.Message);
                }
            }

            // exit without valid data
            return null;
        }
    }
}
