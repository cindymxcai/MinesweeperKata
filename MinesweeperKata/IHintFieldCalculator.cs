namespace MinesweeperKata
{
    public interface IHintFieldCalculator
    {
        CellType[,] ConvertToArray(Field inputField);
        Field CalculateDistances(string[] inputArray);
    }
}