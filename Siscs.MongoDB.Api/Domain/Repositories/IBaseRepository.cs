using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Siscs.MongoDB.Api.Domain.Entities;

namespace Siscs.MongoDB.Api.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        IMongoQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(Guid id);
    }
}