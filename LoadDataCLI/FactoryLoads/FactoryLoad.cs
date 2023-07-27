using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI {
    public class FactoryLoad {
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
        //
        // velocity data
        //
        public List<string> BarrelNames { get; set; } = new List<string>();
        public List<int> Velocities { get; set; } = new List<int>();
        //
        // constructor
        //
        public FactoryLoad(string CartridgeName, string Manufacturer, string BulletName, double BulletWeight) {
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
                $"\n{BulletString}" +
                $"\n\nBarrel\t\tVelocity\n";

            // add each barrel and velocity to the string
            for(int i = 0; i < BarrelNames.Count; i++) {
                output += $"{BarrelNames[i]}\t\t{Velocities[i]}\n";
            }

            // return output string
            return output;
        }
    }
}
