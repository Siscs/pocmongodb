using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Siscs.MongoDB.Api.Domain.Entities
{
    public abstract class Entity
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
        
    }
}