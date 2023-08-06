using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI {
    public class ViewFactoryLoad {
        // entry point, returns a load model or null and exit code
        public static (FactoryLoadModel?, int) View(List<FactoryLoadModel> data) {

            // current load variable
            FactoryLoadModel currentLoad;

            // select a load from database list
            try {
                currentLoad = SelectFactoryLoad.Select(data);
            }
            catch {
                throw new Exception("Failed to select load");
            }

            // display the load information
            if(currentLoad != null) {
                Console.WriteLine();
                Console.WriteLine(currentLoad);
                Console.WriteLine(currentLoad.VelocityTableString);
            }

            // option to update, delete, or go back
            string? userOptionSelection = null;

            do {
                Console.Write("edit || delete || back : ");
                userOptionSelection = Console.ReadLine().Trim().ToLower();

                // user options
                switch(userOptionSelection) {
                    case "edit":
                    case "e":
                        return (currentLoad, 1);
                    case "delete":
                    case "d":
                        return (currentLoad, 2);
                    case "back":
                    case "b":
                        return (null, 3);
                    default:
                        userOptionSelection = null;
                        break;
                }

            } while(userOptionSelection == null);

            return (null, 4);
        }
    }
}
