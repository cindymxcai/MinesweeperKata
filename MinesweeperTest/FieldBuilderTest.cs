using System.Reflection.Emit;
using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class FieldBuilderTest
    {

        [Fact]
        public void FieldShouldReturnNullIfRowOrColAre0()
        {
            var lineParser = new LineParser();
            lineParser.GetSize("33");
            var fieldCreator = new FieldCreator();
            Assert.Null(fieldCreator.ReadField());
        }
    }
}