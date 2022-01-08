namespace zrak.Mappers
{
    public interface ITicTacToeIndexMapper
    {
        (int, int) Map(int baseIndex);
    }
}
