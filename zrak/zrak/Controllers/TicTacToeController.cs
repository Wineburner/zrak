using Microsoft.AspNetCore.Mvc;
using zrak.Models;
using zrak.Services;

namespace zrak.Controllers
{
    public class TicTacToeController : Controller
    {
        private readonly ITicTacToeService _ticTacToeService;

        public TicTacToeController(ITicTacToeService ticTacToeService) 
        {
            _ticTacToeService = ticTacToeService;
        }

        public IActionResult TicTacToeView()
        {
            return View(_ticTacToeService.GetGame());
        }

        public IActionResult CreateNewGame() 
        {
            TicTacToeModel game = new TicTacToeModel();
            _ticTacToeService.CreateGame(game);
            return View(TicTacToeView());
        }

        [HttpGet()]
        public IActionResult OpenGame(string id)
        {
            return View(_ticTacToeService.OpenGame(id));
        }

        public IActionResult ChangeSpace(int space, string id) 
        {
            _ticTacToeService.ChangeSpace(space, id);
            _ticTacToeService.RowCheck(id);
            return View("OpenGame", _ticTacToeService.OpenGame(id));
        }

        public IActionResult DeleteGame(string id) 
        {
            _ticTacToeService.DeleteGame(id);
            return View("TicTacToeView", _ticTacToeService.GetGame());
        }

        public IActionResult ResetGame(string id) 
        {
            id = _ticTacToeService.ResetGame(id);
            return View("OpenGame", _ticTacToeService.OpenGame(id));
        }
    }
}
