namespace MinesweeperKata
{
    public interface IFieldBuilder
    {
        Field ReadField(string[] valueArray, int index);
    }
}