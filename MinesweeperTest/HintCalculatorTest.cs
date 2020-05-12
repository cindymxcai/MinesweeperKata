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
        public void ShouldMakeArrayBasedOnFieldSize(string [] input, int rank, int length )
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

        [Fact]
        public void ShouldConvertFieldToArray()
        {
            var hintFieldCalculator = new HintFieldCalculator();
            var fieldCreator = new FieldCreator();
            fieldCreator.ReadAllFields( new []{"22", "..", "*.", "00"});
            var hintArray = hintFieldCalculator.ConvertToArray(fieldCreator.AllFields[0]);
            Assert.Equal( 4, hintArray.Length);
            Assert.Equal(CellType.Empty, hintArray[0,0]);
            Assert.Equal(CellType.Empty, hintArray[0,1]);
            Assert.Equal(CellType.Mine, hintArray[1,0]);
            Assert.Equal(CellType.Empty, hintArray[1,1]);
        }
        
        [Theory]
        [MemberData(nameof(ListData))]
        public void SurroundingValidCellsFoundCorrectly(List<(int,int)> expectedListOfValidCells, int currentRow, int currentCol, int rows, int cols)
        {
            var hintFieldCalculator = new HintFieldCalculator();
            Assert.Equal(expectedListOfValidCells, hintFieldCalculator.FindSurroundingInBoundCells(currentRow, currentCol, rows , cols) );
        }
        
        private static IEnumerable<object[]> ListData()
        {
            var test1 = new List<(int,int)> {(0,0), (0,2), (1,0), (1,1), (1,2)};
            var test2 = new List<(int,int)> {(0,1), (1,0), (1,1)};
            var test3 = new List<(int,int)> {(0,0), (0,2)};
            var test4 = new List<(int, int)> {(0,0), (0,1), (0,2), (1,0), ( 1,2), (2,0), (2,1), (2,2)};
            yield return new object[] { test1, 0, 1, 3, 3 }; 
            yield return new object[] { test2, 0, 0, 3, 3 }; 
            yield return new object[] { test3, 0, 1, 1, 5 }; 
            yield return new object[] { test4, 1, 1, 3, 3 }; 
        }

        [Fact]
        public void ShouldGetNumberOfSurroundingMinesGivenAnyCell()
        {
            var hintFieldCalculator = new HintFieldCalculator();
            hintFieldCalculator.CalculateNumberOfSurroundingMines();
            var fieldCreator = new FieldCreator();
            var allFields = fieldCreator.ReadAllFields(new []{"22", "*.", "..", "33", "...", "*..", ".*.", "00"});
            var calculatedField =  hintFieldCalculator.CalculateHints(allFields[0]);
           Assert.Equal("*", calculatedField[0,0]);
           Assert.Equal("1", calculatedField[0,1]);

        }
        
        
        
    }
}