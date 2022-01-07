using Xunit;
using zrak.Models;
using zrak.Builders;
using zrak.Mappers;
using zrak.Enumerators;
using Moq;

namespace zrak.Test.Builders
{
    public class TicTacToeBuilderTest
    {
        [Fact]
        public void Should_Build_TicTacToeStoreModel_From_TicTacToeModel_Successful()
        {
            var boardSpaces = new string[,] {
                {" ", " ", " "},
                {" ", " ", " "},
                {" ", " ", " "} };
            var turn = 'X';
            var xwin = 0;
            var owin = 0;
            var initModel = new TicTacToeModel()
            {
                BoardSpaces = boardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin
            };
            var mockMapper = new Mock<ITicTacToeSpaceMapper>();
            mockMapper.Setup(x => x.SpaceMap(" ")).Returns(SpaceState.Empty);
            mockMapper.Setup(x => x.SpaceMap(SpaceState.Empty)).Returns(" ");
            var builder = new TicTacToeBuilder(mockMapper.Object);

            var result = builder.Build(initModel);

            Assert.Equal(boardSpaces, builder.Build(result.BoardSpaces));
            Assert.Equal(turn, result.Turn);
            Assert.Equal(xwin, result.XWins);
            Assert.Equal(owin, result.OWins);
        }

        [Fact]
        public void Should_Build_TicTacToeModel_From_TicTacToeStoreModel_Successful() 
        {
            var boardSpaces = new SpaceState[,] {
                {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty},
                {SpaceState.Empty, SpaceState.Empty, SpaceState.Empty} };
            var turn = 'X';
            var xwin = 0;
            var owin = 0;
            var initModel = new TicTacToeStoreModel()
            {
                BoardSpaces = boardSpaces,
                Turn = turn,
                XWins = xwin,
                OWins = owin
            };
            var mockMapper = new Mock<ITicTacToeSpaceMapper>();
            mockMapper.Setup(x => x.SpaceMap(" ")).Returns(SpaceState.Empty);
            mockMapper.Setup(x => x.SpaceMap(SpaceState.Empty)).Returns(" ");
            var builder = new TicTacToeBuilder(mockMapper.Object);

            var result = builder.Build(initModel);

            Assert.Equal(boardSpaces, builder.Build(result.BoardSpaces));
            Assert.Equal(turn, result.Turn);
            Assert.Equal(xwin, result.XWins);
            Assert.Equal(owin, result.OWins);
        }

    }
}
