namespace LoadDataCLI {
    public class FactoryLoadMain {

        // entry point
        public static void Init() {

            // connect to database
            // mongo connection
            FactoryLoadService factoryLoadService = new();

            // to repeat the input loop
            bool repeat = true;

            // main options
            do {
                Console.Write("view || new || quit : ");

                // option to view existing or create new load
                //
                // to store user input
                // store user input
                string? userOptionSelection = Console.ReadLine().Trim().ToLower();

                //
                // "v" or "view" view data
                //
                if (userOptionSelection == "v" || userOptionSelection == "view") {

                    // store the current load info
                    FactoryLoadModel? currentLoad;

                    // store the view exit code
                    int viewOptionSelection;

                    // run factory load viewer
                    (currentLoad, viewOptionSelection) = ViewFactoryLoad.View(factoryLoadService.GetAsync().Result);

                    // switch to handle view exit code (1 = edit, 2 = delete, 3 = back)
                    switch (viewOptionSelection) {

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
                            if (deleteAnswer == 1) {

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

                //
                // "n" or "new" to create new load
                //
                else if (userOptionSelection == "n" || userOptionSelection == "new") {

                    // create new load
                    FactoryLoadModel? newLoad = CreateFactoryLoad.Create();

                    // if the new load is not null add to database
                    if (newLoad != null) {

                        // add new load to database
                        _ = factoryLoadService.CreateAsync(newLoad);
                    }
                }

                //
                // "q" or "quit" to quit
                //
                else if (userOptionSelection == "q" || userOptionSelection == "quit") {

                    // don't repeat the loop again
                    repeat = false;
                }

                // loop on null user input
            } while (repeat);
        }

    }
}

