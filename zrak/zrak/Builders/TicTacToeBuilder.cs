using System;
using zrak.Models;
using zrak.Enumerators;
using zrak.Mappers;
using MongoDB.Bson;

namespace zrak.Builders
{
    public class TicTacToeBuilder : ITicTacToeBuilder
    {
        private readonly ITicTacToeSpaceMapper _ticTacToeSpaceMapper;

        public TicTacToeBuilder() 
        {
        
        }
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
                    Id = Guid.Parse(ticTacToeModel.Id),
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
                Id = ticTacToeStoreModel.Id.ToString(),
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

        public TicTacToeStoreModel Build(BsonDocument bsonDocument) 
        {
            if (bsonDocument["ClientId"] != null) {
                return new TicTacToeStoreModel
                {
                    Id = Guid.Parse(bsonDocument["ClientId"].ToString()),
                    BoardSpaces = new SpaceState[3, 3]
                {
                        { (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["0,0"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["0,1"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["0,2"].ToString()) },
                        { (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["1,0"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["1,1"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["1,2"].ToString()) },
                        { (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["2,0"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["2,1"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["2,2"].ToString()) }
                },
                    Turn = char.Parse(bsonDocument["Turn"].ToString()),
                    XWins = bsonDocument["XWins"].ToInt32(),
                    OWins = bsonDocument["OWins"].ToInt32(),
                    Ties = bsonDocument["Ties"].ToInt32()
                };
            }

            return new TicTacToeStoreModel
            {
                BoardSpaces = new SpaceState[3, 3]
                {
                        { (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["0,0"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["0,1"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["0,2"].ToString()) },
                        { (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["1,0"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["1,1"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["1,2"].ToString()) },
                        { (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["2,0"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["2,1"].ToString()),
                            (SpaceState)Enum.Parse(typeof(SpaceState), bsonDocument["2,2"].ToString()) }
                },
                Turn = Char.Parse(bsonDocument["Turn"].ToString()),
                XWins = bsonDocument["XWins"].ToInt32(),
                OWins = bsonDocument["OWins"].ToInt32(),
                Ties = bsonDocument["Ties"].ToInt32()
            };
        }
    }
}
