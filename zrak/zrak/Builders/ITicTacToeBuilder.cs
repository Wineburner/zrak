using zrak.Models;
using zrak.Enumerators;

namespace zrak.Builders
{
    public interface ITicTacToeBuilder
    {
        TicTacToeStoreModel Build(TicTacToeModel ticTacToeModel);
        TicTacToeModel Build(TicTacToeStoreModel ticTacToeStoreModel);

        SpaceState[,] Build(string[,] str);
        string[,] Build(SpaceState[,] state);
    }
}
