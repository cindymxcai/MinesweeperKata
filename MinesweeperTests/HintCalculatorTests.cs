using System;
using System.Collections.Generic;
using MinesweeperKata;
using Xunit;

namespace MinesweeperTests
{
    public class HintCalculatorTests
    {
        [Fact]
        public void ConvertFieldToArray()
        {
            var inputReader = new FieldBuilder();
            var fileReader = new TestFileReader(new[]{"22", ".*", "**"});
            var valueArray = fileReader.ReadFile();
            var createdField = inputReader.ReadField(valueArray,0);
            var hintFieldCalculator = new HintFieldCalculator();
            var hintArray = hintFieldCalculator.ConvertToArray(createdField);
            Assert.Equal( 4, hintArray.Length);
            Assert.Equal(CellType.Empty,hintArray[0,0]);
            Assert.Equal(CellType.Mine, hintArray[0,1]);
            Assert.Equal(CellType.Mine, hintArray[1,0]);
            Assert.Equal(CellType.Mine, hintArray[1,1]);
        }

        [Fact]

        public void CalculateNumberOfSurroundingMines()
        {
            var inputReader = new FieldBuilder();
            var fileReader = new TestFileReader(new[]{"22", ".*", "**"});
            var valueArray = fileReader.ReadFile();
            var createdField = inputReader.ReadField(valueArray,0);
            var hintFieldCalculator = new HintFieldCalculator();
            var hintArray = hintFieldCalculator.ConvertToArray(createdField);
            var calculatedField = hintFieldCalculator.CalculateNumberOfSurroundingMines(hintArray, createdField);
            //Assert.Equal("3", calculatedField[0,0]);
            Assert.Equal("*",calculatedField[0,1]);
            Assert.Equal("*", calculatedField[1,0]);
            Assert.Equal("*", calculatedField[1,1]);

        }
 
    }
}