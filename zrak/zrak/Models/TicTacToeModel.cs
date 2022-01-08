namespace zrak.Models
{
    public class TicTacToeModel
    {
        public string Board { get; set; }
        public string Id { get; set; }
        public int XWins { get; set; }
        public int OWins { get; set; }
        public int Ties { get; set; }
        public string[,] BoardSpaces { get; set; }
        public char Turn { get; set; }
    }
}
