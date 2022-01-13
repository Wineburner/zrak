using System;
using zrak.Models;
using zrak.Enumerators;
using zrak.Mappers;

namespace zrak.Builders
{
    public class TicTacToeBuilder : ITicTacToeBuilder
    {
        private readonly ITicTacToeSpaceMapper _ticTacToeSpaceMapper;

        public TicTacToeBuilder(ITicTacToeSpaceMapper ticTacToeSpaceMapper)
        {
            _ticTacToeSpaceMapper = ticTacToeSpaceMapper;
        }

        public TicTacToeStoreModel Build(TicTacToeModel ticTacToeModel)
        {
            if (ticTacToeModel.Id != null)
            { 
                return new TicTacToeStoreModel
                {
                    TicTacToeId = Guid.Parse(ticTacToeModel.Id),
                    BoardSpaces = Build(ticTacToeModel.BoardSpaces),
                    Turn = ticTacToeModel.Turn,
                    XWins = ticTacToeModel.XWins,
                    OWins = ticTacToeModel.OWins,
                    Ties = ticTacToeModel.Ties
                };
            }

            return new TicTacToeStoreModel
            {
                BoardSpaces = Build(ticTacToeModel.BoardSpaces),
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
                Id = ticTacToeStoreModel.TicTacToeId.ToString(),
                BoardSpaces = Build(ticTacToeStoreModel.BoardSpaces),
                Turn = ticTacToeStoreModel.Turn,
                XWins = ticTacToeStoreModel.XWins,
                OWins = ticTacToeStoreModel.OWins,
                Ties = ticTacToeStoreModel.Ties
            };
        }

        public SpaceState[,] Build(string[,] str)
        {
            SpaceState[,] converted = new SpaceState[3, 3] { 
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty} };


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    converted[i, j] = _ticTacToeSpaceMapper.SpaceMap(str[i, j]);
                }
            }

            return converted;
        }

        public string[,] Build(SpaceState[,] state)
        {
            string[,] converted = new string[3, 3]{
                    {" ", " ", " "},
                    {" ", " ", " "},
                    {" ", " ", " "} };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    converted[i, j] = _ticTacToeSpaceMapper.SpaceMap(state[i, j]);
                }
            }

            return converted;
        }
    }
}
