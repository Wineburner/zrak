using zrak.Models;

namespace zrak.Factory
{
    public class TicTacToeModelFactory : ITicTacToeModelFactory
    {
        public TicTacToeModel NewModel() 
        {
            return new TicTacToeModel
            {
                BoardSpaces = new string[3, 3]
                {
                    {" ", " ", " "},
                    {" ", " ", " "},
                    {" ", " ", " "}
                },
                Turn = 'X',
                XWins = 0,
                OWins = 0,
                Ties = 0
            };
        }
    }
}
