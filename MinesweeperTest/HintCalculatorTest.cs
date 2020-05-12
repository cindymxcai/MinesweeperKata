using System.Reflection.Emit;
using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class HintCalculatorTest
    {
        [Fact]
        public void ShouldConvertToArrayToFindSurroundingCells()
        {
            var hintFieldCalculator = new HintFieldCalculator();
            var fieldCreator = new FieldCreator();
            fieldCreator.ReadAllFields(new []{ "22","..", "*.", "00"});
            var fieldArray = hintFieldCalculator.ConvertToArray(fieldCreator.AllFields[0]);
            Assert.Equal(2,fieldArray.Rank);
        }
    }

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