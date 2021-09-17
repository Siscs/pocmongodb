using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Siscs.MongoDB.Api.Domain.Entities;
using Siscs.MongoDB.Api.Domain.Repositories;
using Siscs.MongoDB.Api.Infrastructure.Data.MongoContext;

namespace Siscs.MongoDB.Api.Infrastructure.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IMongoDbContext context)
            : base(context, "Categorias")
        {
        }

        public async Task<IEnumerable<Categoria>> Get(string descricao)
        {
            // var filter = Builders<Categoria>.Filter.Eq("nome", "nome");
            // return await _context.Categorias.Find(filter).ToListAsync();
            return await DbCollection.Find(p => p.Descricao.ToUpper() == descricao.ToUpper()).ToListAsync();
        }

    }
}