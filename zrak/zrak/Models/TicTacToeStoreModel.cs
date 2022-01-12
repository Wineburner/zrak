using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using zrak.Enumerators;

namespace zrak.Models
{
    public class TicTacToeStoreModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid? TicTacToeId { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int XWins { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int OWins { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int Ties { get; set; }
        public SpaceState[,] BoardSpaces { get; set; }
        [BsonRepresentation(BsonType.String)]
        public char Turn { get; set; }
    }
}
