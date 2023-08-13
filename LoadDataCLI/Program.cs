namespace LoadDataCLI {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Load Data");

            // check arguments for factory loads

            /*
             * TODO
             * 
            if (args.Contains("-factory") || args.Contains("-f")) {

            }

            // check arguments for custom loads
            else if (args.Contains("-custom") || args.Contains("-c")) {

            }
            */

            // else if args contains view

            // else if args contains new

            // TODO: pass these into the functions, or refactor to handle them here 

            // select factory or custom load
            Console.Write("Factory || Custom : ");

            // capture user input
            string userSelectionInput = Console.ReadLine().Trim().ToLower();

            // allow "f" for factory
            if (userSelectionInput == "f" || userSelectionInput == "factory") {
                FactoryLoadMain.Init();
            }
<<<<<<< HEAD
<<<<<<< HEAD
            
=======
=======
>>>>>>> main
            else if (userSelectionInput == "c" || userSelectionInput == "custom") {
                CustomLoadMain.Init();
            }

>>>>>>> 92c4a57 (Refactoring)

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}