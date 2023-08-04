using static System.Console;

namespace LoadDataCLI {
    internal class Program {
        private static void Main(string[] args) {
            WriteLine("Load Data");

            // selector result goes here
            FactoryLoadModel currentLoad;

            // connect to mongoDb
            FactoryLoadService factoryLoadService = new FactoryLoadService();

            // get list of factory loads
            Task<List<FactoryLoadModel>> getTask = factoryLoadService.GetAsync();
            List<FactoryLoadModel> factoryLoadList = getTask.Result;

            // user input
            string? userOptionSelection = null;

            // main options
            do {
                WriteLine("1 view || 2 new || 3 quit : ");

                userOptionSelection = ReadLine();

                // 1 to view data
                if(userOptionSelection[..1] == "1" || userOptionSelection == "view") {
                    ViewFactoryLoad.Init(factoryLoadList);
                }
                else if(userOptionSelection[..1] == "2" || userOptionSelection == "new") {
                    CreateFactoryLoad.Create();
                }
                else {
                    break;
                }

            } while(userOptionSelection != "3" && userOptionSelection != "quit");

            WriteLine("\nPress any key to exit...");
            ReadKey();

        }
    }
}