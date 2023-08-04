using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI {
    public class ViewFactoryLoad {
        // entry point
        public static void Init(List<FactoryLoadModel> data) {

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
                Console.WriteLine(currentLoad.VelocityTable);
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
                        userOptionSelection = "e";
                        break;
                    case "delete":
                    case "d":
                        userOptionSelection = "d";
                        break;
                    case "back":
                    case "b":
                        userOptionSelection = "b";
                        break;
                    default:
                        userOptionSelection = null;
                        break;
                }

            } while(userOptionSelection == null);

            // user selection switch
            switch(userOptionSelection) {
                case "e":
                    currentLoad = EditFactoryLoad.Edit(currentLoad);
                    // TODO implement an update function, this only updates the current load variable
                    break;
                case "d":
                    // TODO implement a deletion function
                    break;
                default:
                    break;
            }
        }
    }
}
