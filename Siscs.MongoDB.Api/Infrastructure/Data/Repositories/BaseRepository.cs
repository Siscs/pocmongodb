using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Siscs.MongoDB.Api.Domain.Entities;
using Siscs.MongoDB.Api.Domain.Repositories;
using Siscs.MongoDB.Api.Infrastructure.Data.MongoContext;

namespace Siscs.MongoDB.Api.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly IMongoDbContext _context;
        protected readonly IMongoCollection<TEntity> DbCollection;

        public BaseRepository(IMongoDbContext context, string collectionName = null)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            DbCollection = _context.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> Get(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);
            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbCollection.Find(p => true).ToListAsync();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await DbCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(p => p.Id, entity.Id);
            var result = await DbCollection.ReplaceOneAsync(filter, entity);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);
            var result = await DbCollection.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public IMongoQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            //var result = await DbCollection.FindAsync(expression);
            var query = DbCollection.AsQueryable().Where(expression);
            return query;
            
        }
    }
}