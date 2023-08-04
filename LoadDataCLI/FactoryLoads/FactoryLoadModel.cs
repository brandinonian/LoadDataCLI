using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LoadDataCLI {
    public class FactoryLoadModel {
        //
        // mongodb id
        //
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        //
        // load info
        //
        public string CartridgeName { get; set; }
        public string Manufacturer { get; set; }
        public string BulletName { get; set; }
        public double BulletWeight { get; set; }
        public string BulletString {
            get {
                return $"{BulletWeight} gr {BulletName}";
            }
        }
        public string VelocityTable {
            get {
                return GetVelocityTableString();
            }
        }
        //
        // velocity data
        //
        public List<string> BarrelNames { get; set; } = new List<string>();
        public List<int> Velocities { get; set; } = new List<int>();
        //
        // constructor
        //
        public FactoryLoadModel(string CartridgeName, string Manufacturer, string BulletName, double BulletWeight) {
            this.CartridgeName = CartridgeName;
            this.Manufacturer = Manufacturer;
            this.BulletName = BulletName;
            this.BulletWeight = BulletWeight;
        }
        //
        // ToString()
        //
        public override string ToString() {

            // add properties to string
            string output = $"{Manufacturer}\t\t{CartridgeName}" +
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
            for(int i = 0; i < BarrelNames.Count; i++) {
                output += $"{BarrelNames[i]}\t\t{Velocities[i]}\n";
            }

            // return output string
            return output;
        }
    }
}
