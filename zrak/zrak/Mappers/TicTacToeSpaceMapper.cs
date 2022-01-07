using System;
using zrak.Enumerators;

namespace zrak.Mappers
{
    public class TicTacToeSpaceMapper : ITicTacToeSpaceMapper
    {
        public string SpaceMap(SpaceState baseSpace) =>
                baseSpace switch
                {
                    SpaceState.X => "X",
                    SpaceState.O => "O",
                    SpaceState.Empty => " ",
                    _ => throw new Exception("Please enter a vaild Space.")
                };
        public SpaceState SpaceMap(string baseSpace) =>
            baseSpace switch
            {
                "X" => SpaceState.X,
                "O" => SpaceState.O,
                " " => SpaceState.Empty,
                _ => throw new Exception("Please enter a vaild Space.")
            };
    }
}
