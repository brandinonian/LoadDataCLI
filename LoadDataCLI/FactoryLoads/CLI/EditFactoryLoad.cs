namespace LoadDataCLI {
    public class EditFactoryLoad {

        public static FactoryLoadModel? Edit(FactoryLoadModel data) {
            //
            // display each field and allow for edits
            //

            //
            // edit cartridge selection
            //
            string cartridgeInputString;

            // display current value for reference
            Console.WriteLine($"Cartridge: {data.CartridgeName}");

            // passing a null value (press enter) skips updating this field
            Console.Write("(Enter to skip) New value : ");

            // store user input
            cartridgeInputString = Console.ReadLine();

            // check for null input, update data if not
            if (cartridgeInputString != string.Empty) {
                data.CartridgeName = cartridgeInputString;
            }

            //
            // edit manufacturer
            //
            string manufacturerInputString;

            // display current value for reference
            Console.WriteLine($"Manufacturer: {data.ManufacturerName}");

            // passing a null value (press enter) skips updating this field
            Console.Write("(Enter to skip) New value : ");

            // store user input
            manufacturerInputString = Console.ReadLine();

            // check for null input, update data if not
            if (manufacturerInputString != string.Empty) {
                data.ManufacturerName = manufacturerInputString;
            }

            // display current value for reference
            Console.WriteLine($"Bullet Name: {data.BulletName}");

            // passing a null value (press enter) skips updating this field
            Console.Write("(Enter to skip) New Value : ");

            //
            // edit bullet name
            //
            // store user input
            string? bulletNameInputString = Console.ReadLine();

            // check for null input, update data if not
            if (bulletNameInputString != string.Empty && bulletNameInputString != null) {
                data.BulletName = bulletNameInputString;
            }

            //
            // edit bullet weight (double)
            //
            double? bulletWeightInputDouble = null;

            // try storing user input, loop on exceptions
            bool repeat = true;

            while (repeat) {
                // display current value for reference
                Console.WriteLine($"Bullet Weight: {data.BulletWeight}");

                // passing a null value (press enter) skips updating this field
                Console.Write("(Enter to skip) New Value : ");

                try {
                    bulletWeightInputDouble = double.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch (Exception ex) {
                    repeat = true;
                    Console.WriteLine(ex.Message);
                }

            }

            // check for null input, update data if not
            if (bulletWeightInputDouble != null) {
                data.BulletWeight = (double)bulletWeightInputDouble;
            }

            // return the edited load
            return data;
        }
    }
}
