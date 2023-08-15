namespace LoadDataCLI {
    public class CustomLoadFilters {
        
        // filter by cartridge
        public static List<CustomLoadModel> FilterByCartridge(List<CustomLoadModel> data, string cartridgeName) {

            // list to hold results
            List<CustomLoadModel> results = new();

            // filter input list
            var query =
                from load in data
                where load.CartridgeName == cartridgeName
                select load;

            // add results to list
            foreach (var item in query)
                results.Add(item);

            // return list
            return results;
        }

        // filter by bullet string
        public static List<CustomLoadModel> FilterByBulletString(List<CustomLoadModel> data, string bulletString) {

            // list to hold results
            List<CustomLoadModel> results = new();

            // filter input list
            var query =
                from load in data
                where load.BulletString == bulletString
                select load;

            // add results to list
            foreach (var item in query)
                results.Add(item);

            // return list
            return results;
        }

        // filter by powder
        public static List<CustomLoadModel> FilterByPowderString(List<CustomLoadModel> data, string powderString) {

            // list to hold results
            List<CustomLoadModel> results = new();

            // filter input list
            var query =
                from load in data
                where load.PowderString == powderString
                select load;

            // add results to list
            foreach (var item in query)
                results.Add(item);

            // return list
            return results;
        }
    }
}

