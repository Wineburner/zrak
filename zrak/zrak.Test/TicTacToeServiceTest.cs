using Xunit;
using zrak.Services;

namespace zrak.Test
{
    public class TicTacToeServiceTest
    {
        [Fact]
        public void Should_Say_Tic_Tac_Toe_Successful()
        {
            var service = new TicTacToeService();

            var result = service.GetGame();

            Assert.Equal("Tic-Tac-Toe", result.Board);

        }
    }
}
