using System.Collections.Generic;
using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class ParsingTest
    {
        [Fact]
        public void GivenStringInputShouldGetXandY()
        {
            var lineParser = new LineParser();
            var (x,y) = lineParser.GetSize("3 3");
            Assert.Equal( 3, x);
            Assert.Equal( 3, y);
        }
    }
}