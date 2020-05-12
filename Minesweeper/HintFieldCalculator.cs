namespace Minesweeper
{
    public class HintFieldCalculator
    {
        public  CellType[,] ConvertToArray(Field readField)
        {
            var row = readField.Row;
            var col = readField.Col;
            var hintArray = new CellType[row, col];
            return hintArray;
        }
    }
}