using System.Collections.Generic;
using MinesweeperKata;
using Xunit;

namespace MinesweeperTests
{
    public class HintCalculatorTests
    {
        
        [Theory]
        [MemberData(nameof(ListData))]
        public void SurroundingValidCellsFoundCorrectly(List<(int,int)> expectedList, int currentRow, int currentCol, int rows, int cols)
        {
            var hintFieldCalculator = new HintFieldCalculator();
            Assert.Equal(expectedList, hintFieldCalculator.FindSurroundingInBoundCells(currentRow, currentCol, rows , cols) );
        }
        
        private static IEnumerable<object[]> ListData()
        {
            var test1 = new List<(int,int)>
            {
                (0,0), (0,2), (1,0), (1,1), (1,2)
            };  
            
            var test2 = new List<(int,int)>
            {
                 (0,1), (1,0), (1,1)
            };
            
            var test3 = new List<(int,int)>
            {
                (0,0), (0,2)
            };
            var test4 = new List<(int, int)>
            {
                (0,0), (0,1), (0,2), (1,0), ( 1,2), (2,0), (2,1), (2,2)
            };
            yield return new object[] { test1, 0, 1, 3, 3 }; // 3 rows, 3 columns
            yield return new object[] { test2, 0, 0, 3, 3 }; // 3 rows, 3 columns
            yield return new object[] { test3, 0, 1, 1, 5 }; //one row, 5 columns
            yield return new object[] { test4, 1, 1, 3, 3 }; //3 rows, 3 columns
        }

        [Fact]
        public void ConvertFieldToArray()
        {
            var fieldBuilder = new FieldBuilder();
            var fileReader = new TestFileReader(new[]{"22", ".*", "**"});
            var valueArray = fileReader.ReadFile();
            var createdField = fieldBuilder.ReadField(valueArray,0);
            var hintFieldCalculator = new HintFieldCalculator();
            var hintArray = hintFieldCalculator.ConvertToArray(createdField);
            Assert.Equal( 4, hintArray.Length);
            Assert.Equal(CellType.Empty,hintArray[0,0]);
            Assert.Equal(CellType.Mine, hintArray[0,1]);
            Assert.Equal(CellType.Mine, hintArray[1,0]);
            Assert.Equal(CellType.Mine, hintArray[1,1]);
        }

        [Theory]
        [MemberData (nameof(FileData))]
        public void CalculateNumberOfSurroundingMines(string[] fileRead, int row, int col, string expected)
        {
            var fieldBuilder = new FieldBuilder();
            var fileReader = new TestFileReader(fileRead);
            var valueArray = fileReader.ReadFile();
            var createdField = fieldBuilder.ReadField(valueArray,0);
            var hintFieldCalculator = new HintFieldCalculator();
            var hintArray = hintFieldCalculator.ConvertToArray(createdField);
            var calculatedField = hintFieldCalculator.CalculateNumberOfSurroundingMines(hintArray, createdField);
            Assert.Equal(expected, calculatedField[row,col]);
        }
        
        private static IEnumerable<object[]> FileData()
        {
            var test1 = new []
            {
                "22", ".*", "**"
            };  
            var test2 = new []
            {
                "35", "**...", "....", ".*..."
            };  
          
            yield return new object[] { test1, 0, 0, "3" }; 
            yield return new object[]{test1, 0,1, "*"};
            
            yield return new object[] { test2, 0, 0, "*" }; 
            yield return new object[]{test2, 1,1, "3"};
            yield return new object[]{test2, 2,4, "0"};

        }
        
        [Fact]
        public void CalculateNumberOfSurroundingMinesForAllFields()
        {
            var fieldBuilder = new FieldBuilder();
            var hintFieldCalculator = new HintFieldCalculator();

            var fileReader = new TestFileReader(new []{"22", "*.", "..", "33", "...", "*..", ".*.", "00"});
            var valueArray = fileReader.ReadFile();
            var createdFields = fieldBuilder.ReadAllFields(valueArray);
            var allCalculatedFields = hintFieldCalculator.CalculateAllFields(createdFields);
            Assert.Equal("*", allCalculatedFields[0][0,0]);
            Assert.Equal("1", allCalculatedFields[0][0,1]);

            Assert.Equal("1", allCalculatedFields[1][0,0]);
            Assert.Equal("*", allCalculatedFields[1][1,0]);
            Assert.Equal("2", allCalculatedFields[1][1,1]);
        }
        
        
    }
}