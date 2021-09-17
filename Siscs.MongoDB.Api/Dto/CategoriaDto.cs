using System;

namespace Siscs.MongoDB.Api.Dto
{
    public class CategoriaDto 
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
