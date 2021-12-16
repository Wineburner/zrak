using Microsoft.AspNetCore.Mvc;
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
    }
}
