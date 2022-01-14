using System.Collections.Generic;

namespace zrak.Models
{
    public class TicTacToeListModel
    {
        public IEnumerable<TicTacToeModel> Games { get; set; }
        public int TotalXWins { get; set; }
        public int TotalOWins { get; set; }
        public int TotalTies { get; set; }
    }
}
