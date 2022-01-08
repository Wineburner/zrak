using Xunit;
using zrak.Mappers;

namespace zrak.Test.Mappers
{
    public class TicTacToeIndexMapperTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(2, 0, 2)]
        [InlineData(3, 1, 0)]
        [InlineData(4, 1, 1)]
        [InlineData(5, 1, 2)]
        [InlineData(6, 2, 0)]
        [InlineData(7, 2, 1)]
        [InlineData(8, 2, 2)]
        public void Should_Map_Successful(int baseIndex, int mapIndexOne, int mapIndexTwo) 
        {
            var mapper = new TicTacToeIndexMapper();

            var (resultIndexOne, resultIndexTwo) = mapper.Map(baseIndex);

            Assert.Equal(mapIndexOne, resultIndexOne);
            Assert.Equal(mapIndexTwo, resultIndexTwo);
        }
    }
}
