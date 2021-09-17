using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Siscs.MongoDB.Api.Domain.Entities;

namespace Siscs.MongoDB.Api.Infrastructure.Data.MongoContext
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger<MongoDbContext> _logger;

        public MongoDbContext(ILogger<MongoDbContext> logger, IConfiguration configuration)
        {
            var mongoConnectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var mongoDatabaseName = configuration.GetValue<string>("MongoDb:Database");

            var client = new MongoClient(mongoConnectionString);

            _logger = logger;
            _database = client.GetDatabase(mongoDatabaseName);

            _logger.LogInformation("MongoDB Context initialized.");

            // seed default data
            MongoDbContextSeed.SeedData(GetCollection<Produto>("Produtos"));
            MongoDbContextSeed.SeedData(GetCollection<Categoria>("Categorias"));

        }

        public IMongoCollection<T> GetCollection<T>(string collectionName = null)
        {
            if(!string.IsNullOrEmpty(collectionName))
                return _database.GetCollection<T>(collectionName);

            return _database.GetCollection<T>(typeof(T).Name);
        }
    }
}
