namespace LoadDataCLI {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Load Data");

            // select factory or custom load
            Console.Write("Factory || Custom : ");

            // capture user input
            string userSelectionInput = Console.ReadLine().Trim().ToLower();

            // allow "f" for factory
            if (userSelectionInput == "f" || userSelectionInput == "factory") {
                FactoryLoadMain.Init();
            }


            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}