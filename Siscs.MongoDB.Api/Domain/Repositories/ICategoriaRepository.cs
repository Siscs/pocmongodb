using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Siscs.MongoDB.Api.Domain.Entities;

namespace Siscs.MongoDB.Api.Domain.Repositories
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> Get(string descricao);
    }
}