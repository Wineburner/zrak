using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public char RowCheck(string[,] board)
        {
            string letter = "X";
            for (int i = 0; i <= 1; i++) 
            {
                if (i > 0) 
                {
                    letter = "O";
                }

                if (board[0, 0] == letter && board[0, 1] == letter && board[0, 2] == letter)
                {
                    return char.Parse(letter);
                }
                else if (board[1, 0] == letter && board[1, 1] == letter && board[1, 2] == letter)
                {
                    return char.Parse(letter);
                }
                else if (board[2, 0] == letter && board[2, 1] == letter && board[2, 2] == letter)
                {
                    return char.Parse(letter);
                }
                else if (board[0, 0] == letter && board[1, 0] == letter && board[2, 0] == letter)
                {
                    return char.Parse(letter);
                }
                else if (board[0, 1] == letter && board[1, 1] == letter && board[2, 1] == letter)
                {
                    return char.Parse(letter);
                }
                else if (board[0, 2] == letter && board[1, 2] == letter && board[2, 2] == letter)
                {
                    return char.Parse(letter);
                }
                else if (board[0, 0] == letter && board[1, 1] == letter && board[2, 2] == letter)
                {
                    return char.Parse(letter);
                }
                else if (board[0, 2] == letter && board[1, 1] == letter && board[2, 0] == letter)
                {
                    return char.Parse(letter);
                }
            }

            if (board[0, 0] != " " && board[0, 1] != " " && board[0, 2] != " "
                && board[1, 0] != " " && board[1, 1] != " " && board[1, 2] != " "
                && board[2, 0] != " " && board[2, 1] != " " && board[2, 2] != " ")
            {
                return 'T';
            }

            return 'B';
        }
    }
}
