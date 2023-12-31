﻿namespace LoadDataCLI {
    public class DeleteUtils {

        // ask the user if they are sure they want to delete before proceeding
        public static int ConfirmDelete() {

            // bool for repeating
            bool repeat;

            // ask the user are they sure
            do {
                Console.Write("Are you sure you want to delte this load? (Y/n)");

                // only take the first input letter
                string? userOptionSelection = Console.ReadLine().ToLower().Substring(0, 1);

                // on yes/y return data for deletion
                if (userOptionSelection == "y") {
                    repeat = false;

                    // return the 1 to delete
                    return 1;
                }

                // on no/n return null to cancel
                else if (userOptionSelection == "n") {
                    repeat = false;

                    // return 0 to cancel
                    return 0;
                }

                // catch all other input by repeating
                else {
                    repeat = true;
                }
            } while (repeat);

            // return 0 as default
            return 0;
        }
    }
}
