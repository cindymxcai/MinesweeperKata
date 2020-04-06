namespace MinesweeperKata
{
    public interface IHintFieldCalculator
    {
        CellType[,] ConvertToArray(Field inputField);
        string[,] CalculateNumberOfSurroundingMines(CellType[,] inputArray, Field inputField);
    }
}