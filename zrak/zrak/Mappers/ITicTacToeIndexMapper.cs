using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zrak.Mappers
{
    public interface ITicTacToeIndexMapper
    {
        (int, int) Map(int baseIndex);

        char RowCheck(string[,] board);
    }
}
