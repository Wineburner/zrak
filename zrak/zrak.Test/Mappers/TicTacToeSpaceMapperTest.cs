using Xunit;
using zrak.Mappers;
using zrak.Enumerators;

namespace zrak.Test.Mappers
{
    public class TicTacToeSpaceMapperTest
    {
        [Theory]
        [InlineData(SpaceState.X, "X")]
        [InlineData(SpaceState.O, "O")]
        [InlineData(SpaceState.Empty, " ")]
        public void Should_Map_Space_Successful(SpaceState state, string str) 
        {
            var mapper = new TicTacToeSpaceMapper();

            var resultState = mapper.SpaceMap(str);
            var resultStr = mapper.SpaceMap(state);

            Assert.Equal(resultState, state);
            Assert.Equal(resultStr, str);
        }
    }
}
