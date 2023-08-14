using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LoadDataCLI {
    public class FactoryLoadModel {
        //
        // mongodb id
        //
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {
            get; set;
        }
        //
        // load info
        //
        public string CartridgeName {
            get; set;
        }
        public string ManufacturerName {
            get; set;
        }
        public string BulletName {
            get; set;
        }
        public double BulletWeight {
            get; set;
        }
        public string BulletString {
            get {
                return $"{BulletWeight} gr {BulletName}";
            }
        }
        public string VelocityTableString {
            get {
                return GetVelocityTableString();
            }
        }
        //
        // velocity data
        //
        // TODO refactor to kvp?
        // TODO add methods for updating
        public List<string> BarrelNames { get; set; } = new();
        public List<int> Velocities { get; set; } = new();
        //
        // constructor
        //
        public FactoryLoadModel(string CartridgeName, string ManufacturerName, string BulletName, double BulletWeight) {
            this.CartridgeName = CartridgeName;
            this.ManufacturerName = ManufacturerName;
            this.BulletName = BulletName;
            this.BulletWeight = BulletWeight;
        }
        //
        // properties needed for creating a new load
        //
        public static readonly string[] propertyNames = { "cartridgeName", "manufacturerName", "bulletString" };
        //
        // return an abbreviated description string
        //
        public string ShortString() {

            // add properties to string
            string output = $"{ManufacturerName}\t\t{CartridgeName}" +
                $"\n{BulletString}";

            // return output string
            return output;
        }
        //
        // Velocity Table to string
        //
        public string GetVelocityTableString() {

            // table header
            string output = $"\n\nBarrel\t\tVelocity\n";

            // add each barrel and velocity to the string
            for (int i = 0; i < BarrelNames.Count; i++) {
                output += $"{BarrelNames[i]}\t{Velocities[i]}\n";
            }

            // return output string
            return output;
        }
    }
}