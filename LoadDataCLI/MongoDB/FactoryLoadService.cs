﻿using MongoDB.Driver;

namespace LoadDataCLI {
    // TODO: Revisit this to double check for funciton, move the connection string for portability
    public class FactoryLoadService {

        private readonly IMongoCollection<FactoryLoadModel> _factoryLoadsCollection;

        public FactoryLoadService() {
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("ReloadingData");

            _factoryLoadsCollection = mongoDatabase.GetCollection<FactoryLoadModel>("FactoryLoads");
        }

        public async Task<List<FactoryLoadModel>> GetAsync() =>
            await _factoryLoadsCollection.Find(_ => true).ToListAsync();

        public async Task<FactoryLoadModel?> GetAsync(string id) =>
            await _factoryLoadsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(FactoryLoadModel newFactoryLoad) =>
            await _factoryLoadsCollection.InsertOneAsync(newFactoryLoad);

        public async Task UpdateAsync(string id, FactoryLoadModel updatedFactoryLoad) =>
            await _factoryLoadsCollection.ReplaceOneAsync(x => x.Id == id, updatedFactoryLoad);

        public async Task RemoveAsync(string id) =>
            await _factoryLoadsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
