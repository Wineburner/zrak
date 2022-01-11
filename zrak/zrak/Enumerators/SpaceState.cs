using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace zrak.Enumerators
{
    public enum SpaceState
    {
        [BsonRepresentation(BsonType.String)]
        X,
        [BsonRepresentation(BsonType.String)]
        O,
        [BsonRepresentation(BsonType.String)]
        Empty
    }
}
