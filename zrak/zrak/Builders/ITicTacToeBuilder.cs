using zrak.Models;

namespace zrak.Builders
{
    public interface ITicTacToeBuilder
    {
        TicTacToeStoreModel Build(TicTacToeModel ticTacToeModel);
        TicTacToeModel Build(TicTacToeStoreModel ticTacToeStoreModel);
    }
}
