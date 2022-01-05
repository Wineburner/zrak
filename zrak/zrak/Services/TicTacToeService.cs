using zrak.Models;
using zrak.Stores;
using zrak.Builders;
using zrak.Mappers;
using System.Linq;
using System;

namespace zrak.Services
{
    public class TicTacToeService : ITicTacToeService
    {
        private readonly ITicTacToeStore _ticTacToeStore;
        private readonly ITicTacToeBuilder _ticTacToeBuilder;
        private readonly ITicTacToeIndexMapper _ticTacToeIndexMapper;

        public TicTacToeService(ITicTacToeStore ticTacToeStore, ITicTacToeBuilder ticTacToeBuilder, ITicTacToeIndexMapper ticTacToeIndexMapper)
        {
            _ticTacToeStore = ticTacToeStore;
            _ticTacToeBuilder = ticTacToeBuilder;
            _ticTacToeIndexMapper = ticTacToeIndexMapper;
        }
        public TicTacToeListModel GetGame()
        {
            return new TicTacToeListModel
            {
                Games = _ticTacToeStore.GetAllGames().Select(x => _ticTacToeBuilder.Build(x))
            };
        }

        public void CreateGame(TicTacToeModel ticTacToeModel)
        {
            _ticTacToeStore.CreateGame(_ticTacToeBuilder.Build(ticTacToeModel));
        }

        public TicTacToeModel OpenGame(string id)
        {
            var ticTacToeStore = _ticTacToeStore.ReadGame(Guid.Parse(id));
            return _ticTacToeBuilder.Build(ticTacToeStore);
        }

        public void DeleteGame(string id) 
        {
            _ticTacToeStore.DeleteGame(Guid.Parse(id));
        }

        public string ResetGame(string id) 
        {
            var ticTacToeStore = _ticTacToeStore.ReadGame(Guid.Parse(id));
            ticTacToeStore.Id = Guid.NewGuid();
            ticTacToeStore.BoardSpaces = new string[3, 3]
                {
                    {" ", " ", " "},
                    {" ", " ", " "},
                    {" ", " ", " "}
                };
            ticTacToeStore.Turn = 'X';
            ticTacToeStore.XWins = 0;
            ticTacToeStore.OWins = 0;
            ticTacToeStore.Ties = 0;
            _ticTacToeStore.UpdateGame(ticTacToeStore);
            return ticTacToeStore.Id.ToString();
        }

        public void ChangeSpace(int space, string id)
        {
            var (cordOne, cordTwo) = _ticTacToeIndexMapper.Map(space);
            var ticTacToeStore = _ticTacToeStore.ReadGame(Guid.Parse(id));
            if (ticTacToeStore.BoardSpaces[cordOne, cordTwo] != "X" && ticTacToeStore.BoardSpaces[cordOne, cordTwo] != "O") {
                ticTacToeStore.BoardSpaces[cordOne, cordTwo] = ticTacToeStore.Turn.ToString();
                if (ticTacToeStore.Turn == 'X')
                {
                    ticTacToeStore.Turn = 'O';
                }
                else
                {
                    ticTacToeStore.Turn = 'X';
                }
            }
            _ticTacToeIndexMapper.RowCheck(ticTacToeStore.BoardSpaces);
            _ticTacToeStore.UpdateGame(ticTacToeStore);
        }

        public void RowCheck(string id)
        {
            var ticTacToeStore = _ticTacToeStore.ReadGame(Guid.Parse(id));
            var result = _ticTacToeIndexMapper.RowCheck(ticTacToeStore.BoardSpaces);

            if (result == 'X')
            {
                ticTacToeStore.XWins++;
                ticTacToeStore.BoardSpaces = new string[3, 3]
                {
                    {" ", " ", " "},
                    {" ", " ", " "},
                    {" ", " ", " "}
                };
            }

            else if (result == 'O')
            {
                ticTacToeStore.OWins++;
                ticTacToeStore.BoardSpaces = new string[3, 3]
                {
                    {" ", " ", " "},
                    {" ", " ", " "},
                    {" ", " ", " "}
                };
            }

            else if (result == 'T') 
            {
                ticTacToeStore.Ties++;
                ticTacToeStore.BoardSpaces = new string[3, 3]
                {
                    {" ", " ", " "},
                    {" ", " ", " "},
                    {" ", " ", " "}
                };
            }

            _ticTacToeStore.UpdateGame(ticTacToeStore);
        }
    }
}
