using zrak.Models;
using zrak.Enumerators;

namespace zrak.Services
{
    public interface ITicTacToeService
    {
        TicTacToeListModel GetGame();

        void CreateGame();
        TicTacToeModel OpenGame(string id);
        void DeleteGame(string id);
        string ResetGame(string id);
        void ChangeSpace(int space, string id);
        void RowCheck(string id);
        GameState GetGameState(SpaceState[,] board);
    }
}
