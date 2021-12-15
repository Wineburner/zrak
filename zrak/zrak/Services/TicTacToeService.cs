using zrak.Models;

namespace zrak.Services
{
    public class TicTacToeService : ITicTacToeService
    {
        public TicTacToeModel GetGame()
        {
            return new TicTacToeModel
            {
                Greet = "Tic-Tac-Toe"
            };
        }
    }
}
