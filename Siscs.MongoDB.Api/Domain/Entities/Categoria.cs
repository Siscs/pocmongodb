using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Siscs.MongoDB.Api.Domain.Entities
{
    public class Categoria : Entity
    {
        [BsonElement("Description")]
        public string Descricao { get; set; }
        
        [BsonElement("Active")]
        public bool Ativo { get; set; }
        
    }
}