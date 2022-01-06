using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zrak.Enumerators
{
    public class TicTacToeEnumerator : ITicTacToeEnumerator
    {
        public enum SpaceState
        {
            X,
            O,
            Empty
        }

        public enum GameState
        {
            XWins,
            OWins,
            Tie,
            Running
        }
    }
}
