using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoadDataCLI {
    public class CustomLoadModel {
        //
        // mongodb id
        //
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {
            get; set;
        }
        //
        // cartridge info
        //
        public string? CartridgeName {
            get; set;
        }

        public double? OverallLength {
            get; set;
        }

        public string? BarrelName {
            get; set;
        }
        //
        // bullet infod
        //
        public string? BulletName {
            get; set;
        }

        public string? BulletManufacturer {
            get; set;
        }

        public double? BulletWeight {
            get; set;
        }
        //
        // brass info
        //
        public string? BrassManufacturer {
            get; set;
        }

        public double? BrassAnnealedTime {
            get; set;
        }

        public double? BrassLength {
            get; set;
        }

        public int? BrassNumberFirings {
            get; set;
        }
        //
        // primer info
        //
        public string? PrimerName {
            get; set;
        }

        public string? PrimerManufacturer {
            get; set;
        }
        //
        // powder
        //
        public string? PowderName {
            get; set;
        }

        public string? PowderManufacter {
            get; set;
        }
        //
        // indexes need to be linked
        //
        public List<double> ChargeWeights { get; set; } = new List<double>();

        public List<int> Velocities { get; set; } = new List<int>();

    }
}
