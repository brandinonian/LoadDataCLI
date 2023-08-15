using MongoDB.Driver.Core.Authentication;

namespace LoadDataCLI {
    public class EditCustomLoad {
        public static CustomLoadModel Edit(CustomLoadModel data) {

            // TODO
            // new format to try, if this works update factory load edit

            // list of parameter options
            string[] optionsList = {    "Cartridge",
                                        "Overall Length",
                                        "Barrel",
                                        "Bullet Name",
                                        "Bullet Manufacturer",
                                        "Bullet Weight",
                                        "Brass Manufacturer",
                                        "Brass Annealing Time",
                                        "Brass Length",
                                        "Brass Number of Firings",
                                        "Primer Manufacturer",
                                        "Primer Name",
                                        "Powder Manufacturer",
                                        "Powder Name" };

            // bool for repeating
            bool repeat;

            // variable for user selection
            int userSelection = 0;

            // display each item with a number
            Console.WriteLine();
            for(int i = 0; i < optionsList.Length; i++) {
                Console.WriteLine($"{i + 1}. {optionsList[i]}");
            }

            // ask user for a selection
            do {

                // print to console
                Console.Write("Select an option to edit: ");

                // try parsing input, catch exceptions
                try {

                    userSelection = int.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch(Exception e) {
                    repeat = true;
                    Console.WriteLine(e);
                }

            } while(repeat);

            // user input
            Console.Write("New value: ");
            string userInputString = Console.ReadLine();

            // check for no entry
            if(userInputString != string.Empty) {

                switch(userSelection) {

                    case 1:
                        data.CartridgeName = userInputString;
                        break;
                    case 2:
                        try {
                            data.OverallLength = double.Parse(userInputString);
                            break;
                        }
                        catch(Exception e) {
                            Console.WriteLine(e);
                            break;
                        }
                    case 3:
                        data.BarrelName = userInputString;
                        break;
                    case 4:
                        data.BulletName = userInputString;
                        break;
                    case 5:
                        data.BulletManufacturer = userInputString;
                        break;
                    case 6:
                        try {
                            data.BulletWeight = double.Parse(userInputString);
                            break;
                        }
                        catch(Exception e) {
                            Console.WriteLine(e);
                            break;
                        }
                    case 7:
                        data.BrassManufacturer = userInputString;
                        break;
                    case 8:
                        try {
                            data.BrassAnnealedTime = double.Parse(userInputString);
                            break;
                        }
                        catch(Exception e) {
                            Console.WriteLine(e);
                            break;
                        }
                    case 9:
                        try {
                            data.BrassLength = double.Parse(userInputString);
                            break;
                        }
                        catch(Exception e) {
                            Console.WriteLine(e);
                            break;
                        }
                    case 10:
                        try {
                            data.BrassNumberFirings = int.Parse(userInputString);
                            break;
                        }
                        catch(Exception e) {
                            Console.WriteLine(e);
                            break;
                        }
                    case 11:
                        data.PrimerManufacturer = userInputString;
                        break;
                    case 12:
                        data.PrimerName = userInputString;
                        break;
                    case 13:
                        data.PowderManufacturer = userInputString;
                        break;
                    case 14:
                        data.PowderName = userInputString;
                        break;
                    default:
                        throw new Exception("Invalid option");
                }
            }

            // error out
            return data;
        }
    }
}

