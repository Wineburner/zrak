using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zrak.Models;

namespace zrak.Builders
{
    public class TicTacToeBuilder : ITicTacToeBuilder
    {
        public TicTacToeStoreModel Build(TicTacToeModel ticTacToeModel)
        {
            if (ticTacToeModel.Id != null)
            {
                return new TicTacToeStoreModel
                {
                    Id = Guid.Parse(ticTacToeModel.Id),
                    BoardSpaces = ticTacToeModel.BoardSpaces,
                    Turn = ticTacToeModel.Turn,
                    XWins = ticTacToeModel.XWins,
                    OWins = ticTacToeModel.OWins,
                    Ties = ticTacToeModel.Ties
                };
            }

            return new TicTacToeStoreModel
            {
                BoardSpaces = ticTacToeModel.BoardSpaces,
                Turn = ticTacToeModel.Turn,
                XWins = ticTacToeModel.XWins,
                OWins = ticTacToeModel.OWins,
                Ties = ticTacToeModel.Ties
            };
        }
        public TicTacToeModel Build(TicTacToeStoreModel ticTacToeStoreModel) 
        {
            return new TicTacToeModel
            {
                Id = ticTacToeStoreModel.Id.ToString(),
                BoardSpaces = ticTacToeStoreModel.BoardSpaces,
                Turn = ticTacToeStoreModel.Turn,
                XWins = ticTacToeStoreModel.XWins,
                OWins = ticTacToeStoreModel.OWins,
                Ties = ticTacToeStoreModel.Ties
            };
        }
    }
}
