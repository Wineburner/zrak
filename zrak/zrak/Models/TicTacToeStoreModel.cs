using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zrak.Models
{
    public class TicTacToeStoreModel
    {
        public Guid? Id { get; set; }
        public int XWins { get; set; }
        public int OWins { get; set; }
        public int Ties { get; set; }
        public string[,] BoardSpaces { get; set; }
        public char Turn { get; set; }
    }
}
