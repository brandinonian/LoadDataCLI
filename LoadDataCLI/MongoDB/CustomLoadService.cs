using MongoDB.Driver;

namespace LoadDataCLI {
    public class CustomLoadService {

        private readonly IMongoCollection<CustomLoadModel> _customLoadsCollection;

        public CustomLoadService() {
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("ReloadingData");

            _customLoadsCollection = mongoDatabase.GetCollection<CustomLoadModel>("CustomLoads");
        }

        public async Task<List<CustomLoadModel>> GetAsync() =>
            await _customLoadsCollection.Find(_ => true).ToListAsync();

        public async Task<CustomLoadModel?> GetAsync(string id) =>
            await _customLoadsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CustomLoadModel newFactoryLoad) =>
            await _customLoadsCollection.InsertOneAsync(newFactoryLoad);

        public async Task UpdateAsync(string id, CustomLoadModel updatedFactoryLoad) =>
            await _customLoadsCollection.ReplaceOneAsync(x => x.Id == id, updatedFactoryLoad);

        public async Task RemoveAsync(string id) =>
            await _customLoadsCollection.DeleteOneAsync(x => x.Id == id);
    }
}


