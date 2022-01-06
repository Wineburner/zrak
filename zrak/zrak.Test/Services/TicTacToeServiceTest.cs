using Xunit;
using zrak.Services;
using zrak.Builders;
using zrak.Stores;
using zrak.Models;
using zrak.Mappers;
using Moq;
using System.Linq;
using System.Collections.Generic;
using static zrak.Enumerators.TicTacToeEnumerator;
using zrak.Enumerators;

namespace zrak.Test
{
    public class TicTacToeServiceTest
    {
        [Fact]
        public void Should_Say_Tic_Tac_Toe_Successful()
        {
            var boardSpaces = new SpaceState[,] {
                {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty} };
            var turn = 'X';
            var xwin = 0;
            var owin = 0;
            var initModel = new TicTacToeStoreModel
            {
                BoardSpaces = boardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin

            };
            var correctModel = new TicTacToeModel
            {
                BoardSpaces = boardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin
            };
            var mockMemory = new Mock<ITicTacToeStore>();
            mockMemory.Setup(x => x.GetAllGames()).Returns(new List<TicTacToeStoreModel> { initModel });
            var mockBuilder = new Mock<ITicTacToeBuilder>();
            mockBuilder.Setup(x => x.Build(initModel)).Returns(correctModel);
            var mockMapper = new Mock<ITicTacToeIndexMapper>();
            var mockEnumerator = new Mock<ITicTacToeEnumerator>();
            var service = new TicTacToeService(mockMemory.Object, mockBuilder.Object, mockMapper.Object, mockEnumerator.Object);

            var result = service.GetGame();

            Assert.NotEmpty(result.Games);
            Assert.Equal(boardSpaces, result.Games.ToList()[0].BoardSpaces);
            Assert.Equal(turn, result.Games.ToList()[0].Turn);



        }
    }
}
