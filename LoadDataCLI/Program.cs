namespace LoadDataCLI {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Load Data");

            // store arguments
            string loadArgument = args[0];
            string viewArgument = args[1];

            // set selection to variables
            int loadSeleciton = 0;
            if(loadArgument == "f" || loadArgument == "factory") {
                loadSeleciton = 1;
            }
            else if(loadArgument == "c" || loadArgument == "custom") {
                loadSeleciton = 2;
            }

            int viewSeleciton = 0;
            if(viewArgument == "v" || viewArgument == "view") {
                viewSeleciton = 1;
            }
            else if(viewArgument == "n" || viewArgument == "new") {
                viewSeleciton = 2;
            }

            // factory view
            if(loadSeleciton == 1 && viewSeleciton == 1) {

                // mongo service
                FactoryLoadService factoryLoadService = new FactoryLoadService();

                // store the current load info
                FactoryLoadModel? currentLoad;

                // get the list of loads from mongodb
                List<FactoryLoadModel> loadList = factoryLoadService.GetAsync().Result;

                // store the view exit code
                int viewOptionSelection;

                // run factory load viewer
                (currentLoad, viewOptionSelection) = ViewFactoryLoad.View(loadList);

                // switch to handle view exit code (1 = edit, 2 = delete, 3 = back)
                switch(viewOptionSelection) {

                    //
                    // edit selected load
                    //
                    case 1:

                        // capture the load id
                        string? editID = currentLoad.Id;

                        // edit the current load
                        FactoryLoadModel? newLoad = EditFactoryLoad.Edit(currentLoad); // this function needs fixing

                        // update database
                        _ = factoryLoadService.UpdateAsync(editID, newLoad);
                        break;

                    //
                    // delete selcted load (asks for confirmation)
                    //
                    case 2:

                        // capture the load id
                        string? deleteID = currentLoad.Id;

                        // delete the selected load
                        int deleteAnswer = DeleteFactoryLoad.ConfirmDelete();

                        // if delete function did not return null proceed with deleting the load
                        if(deleteAnswer == 1) {

                            // delete load from database
                            _ = factoryLoadService.RemoveAsync(deleteID);
                            break;
                        }
                        else {
                            break;
                        }

                    //
                    // go back
                    //
                    default:
                        break;
                }

            }

            // factory new
            else if(loadSeleciton == 1 && viewSeleciton == 2) {

                // mongo service
                FactoryLoadService factoryLoadService = new FactoryLoadService();

                // create new load
                FactoryLoadModel? newLoad = CreateFactoryLoad.Create();

                // if the new load is not null add to database
                if(newLoad != null) {

                    // add new load to database
                    _ = factoryLoadService.CreateAsync(newLoad);

                    // display load for user
                    Console.WriteLine(newLoad);
                }
            }

            // custom view
            else if(loadSeleciton == 2 && viewSeleciton == 1) {

                // mongo service
                CustomLoadService customLoadService = new CustomLoadService();

                // store the current load info
                CustomLoadModel? currentLoad;

                // get the list of loads from mongodb
                List<CustomLoadModel> loadList = customLoadService.GetAsync().Result;

                // store the view exit code
                int viewOptionSelection;

                // run factory load viewer
                (currentLoad, viewOptionSelection) = ViewCustomLoad.View(loadList);

                // switch to handle view exit code (1 = edit, 2 = delete, 3 = back)
                switch(viewOptionSelection) {

                    //
                    // edit selected load
                    //
                    case 1:

                        // capture the load id
                        string? editID = currentLoad.Id;

                        // edit the current load
                        CustomLoadModel? newLoad = EditCustomLoad.Edit(currentLoad); // this function needs fixing

                        // update database
                        _ = customLoadService.UpdateAsync(editID, newLoad);

                        // display the new load
                        Console.WriteLine();
                        Console.WriteLine(newLoad);

                        break;

                    //
                    // delete selcted load (asks for confirmation)
                    //
                    case 2:

                        // capture the load id
                        string? deleteID = currentLoad.Id;

                        // delete the selected load
                        int deleteAnswer = DeleteFactoryLoad.ConfirmDelete(); // TODO rename this guy

                        // if delete function did not return null proceed with deleting the load
                        if(deleteAnswer == 1) {

                            // delete load from database
                            _ = customLoadService.RemoveAsync(deleteID);
                            break;
                        }
                        else {
                            break;
                        }

                    //
                    // go back
                    //
                    default:
                        break;
                }
            }

            // custom new
            else if(loadSeleciton == 2 && viewSeleciton == 2) {
                 
                // mongo service
                CustomLoadService customLoadService = new CustomLoadService();

                // create new load
                CustomLoadModel? newLoad = CreateCustomLoad.Create();

                // if the new load is not null add to database
                if(newLoad != null) {

                    // add new load to database
                    _ = customLoadService.CreateAsync(newLoad);

                    // display load for user
                    Console.WriteLine(newLoad);
                }
            }

            // else display help
            else {
                Console.WriteLine("loaddataCLI Help:\nFirst argument: <factory> <custom>\nSecond argument: <view> <new>");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}