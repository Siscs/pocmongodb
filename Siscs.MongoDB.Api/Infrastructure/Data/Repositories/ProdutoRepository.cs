using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Siscs.MongoDB.Api.Domain.Entities;
using Siscs.MongoDB.Api.Domain.Repositories;
using Siscs.MongoDB.Api.Infrastructure.Data.MongoContext;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Siscs.MongoDB.Api.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IMongoDbContext context)
            : base(context, "Produtos")
        {
        }

        public async Task<IEnumerable<Produto>> GetByCategoria(string categoria)
        {
            // var filter = Builders<Produto>.Filter.Eq("categoria", "categoria");
            // return await _context.Produtos.Find(filter).ToListAsync();
            //return await _context.Produtos.Find(p => p.Categoria.ToUpper() == categoria.ToUpper()).ToListAsync();
            return await DbCollection.Find(_ => true).ToListAsync();
        }
        
        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            // var filter = Builders<Produto>.Filter.Eq("nome", "nome");
            // return await _context.Produtos.Find(filter).ToListAsync();
            return await DbCollection.Find(p => p.Nome.ToUpper() == nome.ToUpper()).ToListAsync();
        }

    }
}