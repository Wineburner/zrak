using zrak.Models;
using zrak.Enumerators;
using MongoDB.Bson;

namespace zrak.Builders
{
    public interface ITicTacToeBuilder
    {
        TicTacToeStoreModel Build(TicTacToeModel ticTacToeModel);
        TicTacToeModel Build(TicTacToeStoreModel ticTacToeStoreModel);

        SpaceState[,] Build(string[,] str);
        string[,] Build(SpaceState[,] state);

        TicTacToeStoreModel Build(BsonDocument bsonDocument);
    }
}
