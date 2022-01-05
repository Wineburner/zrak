using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zrak.Models
{
    public class TicTacToeListModel
    {
        public IEnumerable<TicTacToeModel> Games { get; set; }
    }
}
