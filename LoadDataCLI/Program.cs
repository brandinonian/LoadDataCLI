using static System.Console;

namespace LoadDataCLI {
    internal class Program {
        private static void Main(string[] args) {
            WriteLine("Load Data");

            // selector result goes here
            FactoryLoadModel currentLoad;

            // user input
            int? userInputInt = null;

            // main options
            do {
                WriteLine("[1] View Data [2] New Load [3] Quit: ");

                try {
                    userInputInt = int.Parse(ReadLine());
                }
                catch(Exception ex) {
                    WriteLine(ex.Message);
                }

                // 1 to view data
                if(userInputInt == 1) {
                    // select load, returns FactoryLoad type
                    try {
                        currentLoad = SelectFactoryLoad.Init();

                        // display selected load
                        WriteLine();
                        WriteLine(currentLoad.ToString());
                    }
                    catch(Exception ex) {
                        WriteLine(ex.Message);
                    }

                    // user option to edit load or go back

                }
                else if(userInputInt == 2) {
                    // create a new load
                    throw new NotImplementedException();
                }
                else {
                    break;
                }

            } while(userInputInt != 3);

            WriteLine("\nPress any key to exit...");
            ReadKey();

        }
    }
}