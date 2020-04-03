namespace MinesweeperKata
{
    public interface IInputReader
    {
        Field ReadField(string[] valueArray, int index);
    }
}