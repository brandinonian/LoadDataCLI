using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LoadDataCLI {
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
