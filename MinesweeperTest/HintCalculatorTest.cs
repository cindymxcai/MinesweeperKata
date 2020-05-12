using System.Collections.Generic;
using System.Reflection.Emit;
using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class HintCalculatorTest
    {
        [Theory]
        [MemberData(nameof(InputData))]
        public void ShouldConvertToArrayToFindSurroundingCells(string [] input, int rank, int length )
        {
            var hintFieldCalculator = new HintFieldCalculator();
            var fieldCreator = new FieldCreator();
            fieldCreator.ReadAllFields( input);
            var fieldArray = hintFieldCalculator.ConvertToArray(fieldCreator.AllFields[0]);
            Assert.Equal(rank,fieldArray.Rank);
            Assert.Equal(length,fieldArray.Length);
        }
        
        private static IEnumerable<object[]> InputData()
        {
            var test1 = new[] {"33", "...", "...", "...", "00"};
            var test2 = new[] {"12", "..", "00"};
            var test3 = new[] {"31", ".", ".","*","00"};
            yield return new object[] {test1, 2, 9};
            yield return new object[] {test2, 2, 2};
            yield return new object[] {test3, 2, 3};
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