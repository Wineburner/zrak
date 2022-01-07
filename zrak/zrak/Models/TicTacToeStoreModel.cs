using System;
using zrak.Enumerators;

namespace zrak.Models
{
    public class TicTacToeStoreModel
    {
        public Guid? Id { get; set; }
        public int XWins { get; set; }
        public int OWins { get; set; }
        public int Ties { get; set; }
        public SpaceState[,] BoardSpaces { get; set; }
        public char Turn { get; set; }
    }
}
