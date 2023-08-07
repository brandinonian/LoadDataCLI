namespace LoadDataCLI {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Load Data");

            // store first argument as option selection
            string? optionSeleciton = null;

            if (args.Length > 0) {
                optionSeleciton = args[0];
            }

            // if no arguments are passed display user options
            if(optionSeleciton == null) {

                // select factory or custom load
                Console.Write("Factory || Custom : ");

                // capture user input
                optionSeleciton = Console.ReadLine().Trim().ToLower();

            }
            
                // allow "f" for factory
                if(optionSeleciton == "f" || optionSeleciton == "factory") {
                    FactoryLoadMain.Init();
                }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}