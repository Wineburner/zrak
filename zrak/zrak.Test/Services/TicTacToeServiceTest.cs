using Xunit;
using zrak.Services;
using zrak.Builders;
using zrak.Stores;
using zrak.Models;
using zrak.Mappers;
using zrak.Factory;
using Moq;
using System.Linq;
using System.Collections.Generic;
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
            var unconvertedBoardSpaces = new string[,]
            {
               {" ", " ", " "},
                {" ", " ", " "},
                {" ", " ", " "}
            };
            var initModel = new TicTacToeStoreModel
            {
                BoardSpaces = boardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin

            };
            var correctModel = new TicTacToeModel
            {
                BoardSpaces = unconvertedBoardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin
            };
            var mockMemory = new Mock<ITicTacToeStore>();
            mockMemory.Setup(x => x.GetAllGames()).Returns(new List<TicTacToeStoreModel> { initModel });
            var mockBuilder = new Mock<ITicTacToeBuilder>();
            mockBuilder.Setup(x => x.Build(initModel)).Returns(correctModel);
            var mockMapper = new Mock<ITicTacToeIndexMapper>();
            var mockFactory = new Mock<ITicTacToeModelFactory>();
            var service = new TicTacToeService(mockMemory.Object, mockBuilder.Object, mockMapper.Object, mockFactory.Object);

            var result = service.GetGame();

            Assert.NotEmpty(result.Games);
            Assert.Equal(unconvertedBoardSpaces, result.Games.ToList()[0].BoardSpaces);
            Assert.Equal(turn, result.Games.ToList()[0].Turn);
        }

        [Fact]
        public void Should_Align_Successful()
        {
            var boardSpaces = new SpaceState[,]
            {
                {SpaceState.X, SpaceState.O, SpaceState.X},
                {SpaceState.O, SpaceState.O, SpaceState.X},
                {SpaceState.O, SpaceState.X, SpaceState.X}
            };
            var turn = 'X';
            var xwin = 0;
            var owin = 0;
            var unconvertedBoardSpaces = new string[,]
            {
                {"X", "O", "X"},
                {"O", "O", "X"},
                {"O", "X", "X"}
            };
            var initModel = new TicTacToeStoreModel
            {
                BoardSpaces = boardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin

            };
            var correctModel = new TicTacToeModel
            {
                BoardSpaces = unconvertedBoardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin
            };
            var mockMemory = new Mock<ITicTacToeStore>();
            mockMemory.Setup(x => x.GetAllGames()).Returns(new List<TicTacToeStoreModel> { initModel });
            var mockBuilder = new Mock<ITicTacToeBuilder>();
            mockBuilder.Setup(x => x.Build(initModel)).Returns(correctModel);
            var mockMapper = new Mock<ITicTacToeIndexMapper>();
            var mockFactory = new Mock<ITicTacToeModelFactory>();
            var service = new TicTacToeService(mockMemory.Object, mockBuilder.Object, mockMapper.Object, mockFactory.Object);

            var result = service.GetGameState(boardSpaces);

            Assert.Equal(GameState.XWins, result);
        }
    }
}
