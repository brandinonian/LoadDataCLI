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
        public string CartridgeName {
            get; set;
        }
        public double OverallLength {
            get; set;
        }
        public string BarrelName {
            get; set;
        }
        //
        // bullet info
        //
        public string BulletName {
            get; set;
        }
        public string BulletManufacturer {
            get; set;
        }
        public double BulletWeight {
            get; set;
        }
        public string BulletString {
            get {
                return $"{BulletManufacturer} {BulletWeight} gr {BulletName}";
            }
        }
        //
        // brass info
        //
        public string BrassManufacturer {
            get; set;
        }
        public double BrassAnnealedTime {
            get; set;
        }
        public double BrassLength {
            get; set;
        }
        public int BrassNumberFirings {
            get; set;
        }
        //
        // primer info
        //
        public string PrimerManufacturer {
            get; set;
        }
        public string PrimerName {
            get; set;
        }
        public string PrimerString {
            get {
                return $"{PrimerManufacturer} {PrimerName}";
            }
        }
        //
        // powder
        //
        public string PowderManufacturer {
            get; set;
        }
        public string PowderName {
            get; set;
        }
        public string PowderString {
            get {
                return $"{PowderManufacturer} {PowderName}";
            }
        }
        //
        // indexes need to be linked
        //
        public List<double> ChargeWeights { get; set; } = new();
        public List<int> Velocities { get; set; } = new();
        //
        // constructor
        //
        public CustomLoadModel(string CartridgeName,
                               double OverallLength,
                               string BarrelName,
                               string BulletName,
                               string BulletManufacturer,
                               double BulletWeight,
                               string BrassManufacturer,
                               double BrassAnnealedTime,
                               double BrassLength,
                               int BrassNumberFirings,
                               string PrimerManufacturer,
                               string PrimerName,
                               string PowderManufacturer,
                               string PowderName) {
            this.CartridgeName = CartridgeName;
            this.OverallLength = OverallLength;
            this.BarrelName = BarrelName;
            this.BulletName = BulletName;
            this.BulletManufacturer = BulletManufacturer;
            this.BulletWeight = BulletWeight;
            this.BrassManufacturer = BrassManufacturer;
            this.BrassLength = BrassLength;
            this.BrassAnnealedTime = BrassAnnealedTime;
            this.BrassNumberFirings = BrassNumberFirings;
            this.PrimerManufacturer = PrimerManufacturer;
            this.PrimerName = PrimerName;
            this.PowderManufacturer = PowderManufacturer;
            this.PowderName = PowderName;
        }
        //
        // return an abbreviated description string
        //
        public string ShortString() {
            return $"Cartridge: {CartridgeName} Bullet: {BulletString}\nPowder: {PowderString} Primer: {PrimerString} Brass: {BrassManufacturer}\nBarrel: {BarrelName}";
        }
    }
}
