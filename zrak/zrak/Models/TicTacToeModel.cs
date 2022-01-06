using static zrak.Enumerators.TicTacToeEnumerator;

namespace zrak.Models
{
    public class TicTacToeModel
    {
        public string Board { get; set; }
        public string Id { get; set; }
        public int XWins { get; set; }
        public int OWins { get; set; }
        public int Ties { get; set; }
        public SpaceState[,] BoardSpaces { get; set; }
        public char Turn { get; set; }
    }
}
