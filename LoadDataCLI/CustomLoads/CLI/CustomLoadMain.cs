namespace LoadDataCLI {
    public class CustomLoadMain {
        public static void Init() {


            // connect to database
            // mongo connection
            CustomLoadService customLoadService = new();

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

                    // fetch load list
                    List<CustomLoadModel> loadList = customLoadService.GetAsync().Result;

                    // store the current load info
                    CustomLoadModel? currentLoad;

                    // store the view exit code
                    int viewOptionSelection;

                    // run factory load viewer
                    (currentLoad, viewOptionSelection) = ViewCustomLoad.View(loadList);

                    // switch to handle view exit code (1 = edit, 2 = delete, 3 = back)
                    switch (viewOptionSelection) {

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

                //
                // "n" or "new" to create new load
                //
                else if (userOptionSelection == "n" || userOptionSelection == "new") {

                    // create new load
                    CustomLoadModel? newLoad = CreateCustomLoad.Create();

                    // if the new load is not null add to database
                    if (newLoad != null) {

                        // add new load to database
                        _ = customLoadService.CreateAsync(newLoad);
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