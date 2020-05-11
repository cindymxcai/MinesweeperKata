using System.Collections.Generic;
using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class ParsingTest
    {
        [Theory]
        [InlineData("33", 3, 3)]
        [InlineData("35", 3, 5)]
        [InlineData("18", 1, 8)]


        public void GivenStringInputShouldGetXandY(string input, int expectedX, int expectedY)
        {
            var lineParser = new LineParser();
            var (x,y) = lineParser.GetSize(input);
            Assert.Equal( expectedX, x);
            Assert.Equal( expectedY, y);
        }
    }
}