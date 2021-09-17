using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscs.MongoDB.Api.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public ProdutoCategoria Categoria { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }

    }

}
