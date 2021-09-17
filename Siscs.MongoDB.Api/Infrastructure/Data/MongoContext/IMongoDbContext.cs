using MongoDB.Driver;
using Siscs.MongoDB.Api.Domain.Entities;

namespace Siscs.MongoDB.Api.Infrastructure.Data.MongoContext
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName = null);
    }
}
