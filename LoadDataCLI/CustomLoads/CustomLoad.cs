using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataCLI.CustomLoads {
    public class CustomLoad {

        // TODO: upate null values
        //
        // cartridge info
        //

        public string? CartridgeName { get; set; } = null;

        public double? OverallLength { get; set; } = null;

        public string? BarrelName { get; set; } = null;

        //
        // bullet infod
        //

        public string? BulletName { get; set; } = null;

        public string? BulletManufacturer { get; set; } = null;

        public double? BulletWeight { get; set; } = null;

        //
        // brass info
        //

        public string? BrassManufacturer { get; set; } = null;

        public double? BrassAnnealedTime { get; set; } = null;

        public double? BrassLength { get; set; } = null;

        public int? BrassNumberFirings { get; set; } = null;

        //
        // primer info
        //

        public string? PrimerName { get; set; } = null;

        public string? PrimerManufacturer { get; set; } = null;

        //
        // powder
        //

        public string? PowderName { get; set; } = null;

        public string? PowderManufacter { get; set; } = null;

        // indexes need to be linked

        public List<double> ChargeWeights { get; set; } = new List<double>();

        public List<int> Velocities { get; set; } = new List<int>();

    }
}
