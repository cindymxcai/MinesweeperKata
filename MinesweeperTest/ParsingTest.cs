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
        public void GivenStringInputShouldGetXAndY(string input, int expectedX, int expectedY)
        {
            var (x, y) = LineParser.GetSize(input);
            Assert.Equal(expectedX, x);
            Assert.Equal(expectedY, y);
        }

        [Theory]
        [InlineData("")]
        [InlineData("!")]
        [InlineData("-1")]
        [InlineData("w")]
        [InlineData("L")]
        [InlineData("  ")]
        [InlineData(" ")]
        [InlineData("5")]
        public void GivenWrongInputShouldThrowException(string input)
        {
            Assert.Throws<InvalidInputException>(() => LineParser.GetSize(input));
        }

        [Theory]
        [InlineData("*..", CellType.Mine, CellType.Empty)]
        public void GetFieldFromString(string input, CellType mine, CellType empty )
        {
            var row = LineParser.GetFieldRow(input);
            Assert.Equal(mine, row[0]);
            Assert.Equal(empty, row[1]);
            Assert.Equal(empty, row[2]);
        }
    }
}