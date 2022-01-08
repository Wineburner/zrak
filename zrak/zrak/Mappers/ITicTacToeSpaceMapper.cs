using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zrak.Enumerators;

namespace zrak.Mappers
{
    public interface ITicTacToeSpaceMapper
    {
        string SpaceMap(SpaceState baseSpace);
        SpaceState SpaceMap(string baseSpace);
    }
}
