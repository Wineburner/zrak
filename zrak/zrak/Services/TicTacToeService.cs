using zrak.Models;
using zrak.Stores;
using zrak.Builders;
using zrak.Mappers;
using zrak.Enumerators;
using zrak.Factory;
using System.Linq;
using System;

namespace zrak.Services
{

    public class TicTacToeService : ITicTacToeService
    {
        private readonly ITicTacToeStore _ticTacToeStore;
        private readonly ITicTacToeBuilder _ticTacToeBuilder;
        private readonly ITicTacToeIndexMapper _ticTacToeIndexMapper;
        private readonly ITicTacToeModelFactory _ticTacToeModelFactory;

        public TicTacToeService(ITicTacToeStore ticTacToeStore, ITicTacToeBuilder ticTacToeBuilder, ITicTacToeIndexMapper ticTacToeIndexMapper, ITicTacToeModelFactory ticTacToeModelFactory)
        {
            _ticTacToeStore = ticTacToeStore;
            _ticTacToeBuilder = ticTacToeBuilder;
            _ticTacToeIndexMapper = ticTacToeIndexMapper;
            _ticTacToeModelFactory = ticTacToeModelFactory;
        }
        public TicTacToeListModel GetGame()
        {
            var ticTacToeListModel = new TicTacToeListModel
            {
                Games = _ticTacToeStore.GetAllGames().Select(x => _ticTacToeBuilder.Build(x))
            };
            var totalXWins = 0;
            var totalOWins = 0;
            var totalTies = 0;

            foreach (var games in ticTacToeListModel.Games) 
            {
                totalXWins += games.XWins;
                totalOWins += games.OWins;
                totalTies += games.Ties;
            }

            ticTacToeListModel.TotalXWins = totalXWins;
            ticTacToeListModel.TotalOWins = totalOWins;
            ticTacToeListModel.TotalTies = totalTies;
            return ticTacToeListModel;
        }

        public void CreateGame()
        {
            var ticTacToeModel = _ticTacToeModelFactory.NewModel();
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
            ticTacToeStore.TicTacToeId = Guid.NewGuid();
            ticTacToeStore.BoardSpaces = new SpaceState[3, 3]
                {
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty}
                };
            ticTacToeStore.Turn = 'X';
            ticTacToeStore.XWins = 0;
            ticTacToeStore.OWins = 0;
            ticTacToeStore.Ties = 0;
            _ticTacToeStore.UpdateGame(ticTacToeStore);
            return ticTacToeStore.TicTacToeId.ToString();
        }

        public void ChangeSpace(int space, string id)
        {
            var (cordOne, cordTwo) = _ticTacToeIndexMapper.Map(space);
            var ticTacToeStore = _ticTacToeStore.ReadGame(Guid.Parse(id));
            if (ticTacToeStore.BoardSpaces[cordOne, cordTwo] != SpaceState.X && ticTacToeStore.BoardSpaces[cordOne, cordTwo] != SpaceState.O) {
                ticTacToeStore.BoardSpaces[cordOne, cordTwo] = ticTacToeStore.Turn == 'X' ? SpaceState.X : SpaceState.O;

                if (ticTacToeStore.Turn == 'X')
                {
                    ticTacToeStore.Turn = 'O';
                }
                else
                {
                    ticTacToeStore.Turn = 'X';
                }
            }
            GetGameState(ticTacToeStore.BoardSpaces);
            _ticTacToeStore.UpdateGame(ticTacToeStore);
        }

        public void RowCheck(string id)
        {
            var ticTacToeStore = _ticTacToeStore.ReadGame(Guid.Parse(id));
            var result = GetGameState(ticTacToeStore.BoardSpaces);

            if (result == GameState.XWins)
            {
                ticTacToeStore.XWins++;
                ticTacToeStore.BoardSpaces = new SpaceState[3, 3]
                {
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty}
                };
            }

            else if (result == GameState.OWins)
            {
                ticTacToeStore.OWins++;
                ticTacToeStore.BoardSpaces = new SpaceState[3, 3]
                {
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty}
                };
            }

            else if (result == GameState.Tie) 
            {
                ticTacToeStore.Ties++;
                ticTacToeStore.BoardSpaces = new SpaceState[3, 3]
                {
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                    {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty}
                };
            }

            _ticTacToeStore.UpdateGame(ticTacToeStore);
        }

        public GameState GetGameState(SpaceState[,] board)
        {
            if (board[0, 0] != SpaceState.Empty && board[0, 1] != SpaceState.Empty &&
                     board[0, 2] != SpaceState.Empty && board[1, 0] != SpaceState.Empty &&
                     board[1, 1] != SpaceState.Empty && board[1, 2] != SpaceState.Empty &&
                     board[2, 0] != SpaceState.Empty && board[2, 1] != SpaceState.Empty &&
                     board[2, 2] != SpaceState.Empty)
            {
                return GameState.Tie;
            }
            else if (board[0, 0] != SpaceState.Empty && board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
            {
                return board[0, 0] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }
            else if (board[1, 0] != SpaceState.Empty && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
            {
                return board[1, 0] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }
            else if (board[2, 0] != SpaceState.Empty && board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
            {
                return board[2, 0] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }
            else if (board[0, 0] != SpaceState.Empty && board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
            {
                return board[0, 0] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }
            else if (board[0, 1] != SpaceState.Empty && board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
            {
                return board[0, 1] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }
            else if (board[0, 2] != SpaceState.Empty && board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
            {
                return board[0, 2] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }
            else if (board[0, 0] != SpaceState.Empty && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }
            else if (board[0, 2] != SpaceState.Empty && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2] == SpaceState.X ? GameState.XWins : GameState.OWins;
            }

            return GameState.Running;
        }
    }
}
