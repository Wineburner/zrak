﻿using System;

namespace zrak.Mappers
{
    public class TicTacToeIndexMapper : ITicTacToeIndexMapper
    {
        public (int, int) Map(int baseIndex) =>
                baseIndex switch
                {
                    0 => (0, 0),
                    1 => (0, 1),
                    2 => (0, 2),
                    3 => (1, 0),
                    4 => (1, 1),
                    5 => (1, 2),
                    6 => (2, 0),
                    7 => (2, 1),
                    8 => (2, 2),
                    _ => throw new Exception("Please enter a vaild number.")
                };
    }
}
