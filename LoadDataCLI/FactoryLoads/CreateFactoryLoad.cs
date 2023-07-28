using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI.FactoryLoads {
    public class CreateFactoryLoad {

        public static FactoryLoadModel Init() {

            // connect to mongodb
            FactoryLoadService factoryLoadService = new FactoryLoadService();

            // user input
            int? userInputInt = null;

            // user input for load parameters
            do {
                // cartridge
                Console.WriteLine("Enter the cartridge: ");
                string cartridgeName = Console.ReadLine();

                // manufacturer
                Console.WriteLine("Enter the manufacturer: ");
                string manufacturer = Console.ReadLine();

                // bullet name
                Console.WriteLine("Enter the bullet name: ");
                string bulletName = Console.ReadLine();

                // bullet weight (double)
                double bulletWeight;
                bool repeat = true;

                while (!repeat) {
                    Console.Write("Enter the bullet weight: ");
                    
                    // catch exceptions
                    try {
                        bulletWeight = double.Parse(Console.ReadLine());
                        repeat = false;
                    } catch(Exception ex) { 
                        Console.WriteLine(ex.Message);
                    }
                }
                
                

            } while(userInputInt != 3);
        }
    }
}
