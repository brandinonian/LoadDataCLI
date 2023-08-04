using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI.CLI {
    public class DeleteLoad {

        // ask the user if they are sure they want to delete before proceeding
        public static FactoryLoadModel? Delete(FactoryLoadModel data) {
            bool repeat = true;
            string? userOptionSelection = null;

            // ask the user are they sure
            do {
                Console.Write("Are you sure you want to delte this load? (Y/n)");

                // only take the first input letter
                userOptionSelection = Console.ReadLine().ToLower().Substring(0, 1);

                // on yes/y return data for deletion
                if(userOptionSelection == "y") {
                    repeat = false;
                    return data;
                }

                // on no/n return null to cancel
                else if(userOptionSelection == "n") {
                    repeat = false;
                    return null;
                }

                // catch all other input by repeating
                else {
                    repeat = true;
                }
            } while(repeat);

            // return null as default
            return null;
        }
    }
}
