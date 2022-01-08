using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zrak.Models;

namespace zrak.Stores
{
    public interface ITicTacToeStore
    {
        void CreateGame(TicTacToeStoreModel ticTacToeStoreModel);
        TicTacToeStoreModel ReadGame(Guid id);
        void UpdateGame(TicTacToeStoreModel ticTacToeStoreModel);
        void DeleteGame(Guid id);
        IEnumerable<TicTacToeStoreModel> GetAllGames();
    }
}
