using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace zrak.Models
{
    public class BlogStoreModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid? BlogId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string Title { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string Body { get; set; }
    }
}
