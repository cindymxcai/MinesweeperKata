using System.Linq;
using MinesweeperKata;
using Xunit;

namespace MinesweeperTests
{
    public class ParsingTests
    {
        [Theory]
        [InlineData("44", 4, 4)]
        [InlineData("35", 3, 5)]
        public void GetSizeFromString(string stringInput, int expectedX, int expectedY)
        {
            var lineParser = new LineParser();
            var (x,y) = lineParser.GetSize(stringInput);
            Assert.Equal( expectedX, x);
            Assert.Equal( expectedY, y);
        }
        
        [Theory]
        [InlineData("L#")]
        [InlineData("Ls#")]
        [InlineData("L12#")]
        [InlineData("L  #")]
        [InlineData("L\\#")]
        [InlineData("1")]
        [InlineData("L")]
        [InlineData("")]
        [InlineData("3A")]
        public void GetSizeWithInvalidInput(string stringInput)
        {
            LineParser lineParser = new LineParser();
            Assert.Throws<LineParserException>(()=> lineParser.GetSize(stringInput));
        }

        [Fact]
        public void GetFieldFromString()
        {
            var lineParser = new LineParser();
            var row  = lineParser.GetFieldRow("*..");
            Assert.Equal(CellType.Mine,row.First());
            Assert.Equal(CellType.Empty, row[1]);
            Assert.Equal(CellType.Empty, row[2]);
            
        }
    }
}