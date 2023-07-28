using static System.Console;

namespace LoadDataCLI {
    internal class Program {
        private static void Main(string[] args) {
            WriteLine("Load Data");

            // selector result goes here
            FactoryLoadModel currentLoad;

            // hardcoded list for testing
            FactoryLoadService factoryLoadService = new FactoryLoadService();
            Task<List<FactoryLoadModel>> getTask = factoryLoadService.GetAsync();
            List<FactoryLoadModel> data = getTask.Result;

            //// add items to the list
            //data.Add(new FactoryLoadModel("6MM ARC", "Hornady", "ELD-M", 108.0));
            //data.Add(new FactoryLoadModel("5.56", "Lake City", "FMJ", 55.0));
            //data.Add(new FactoryLoadModel("5.56", "Lake City", "FMJ", 62.0));
            //data.Add(new FactoryLoadModel("9MM", "Federal", "FMJ", 115.0));

            //// add barrel names and velocities
            //data[0].BarrelNames.Add("18\" Gas");
            //data[0].Velocities.Add(2450);
            //data[1].BarrelNames.Add("18\"SS");
            //data[1].Velocities.Add(2950);
            //data[2].BarrelNames.Add("18\"SS");
            //data[2].Velocities.Add(2850);
            //data[3].BarrelNames.Add("Glock 45");
            //data[3].Velocities.Add(1150);

            // select load, returns FactoryLoad type
            try {
                currentLoad = FactoryLoadSelector.Init(data);

                // display selected load
                WriteLine();
                WriteLine(currentLoad.ToString());
            }
            catch(Exception ex) {
                WriteLine(ex.Message);
            }

        }
    }
}