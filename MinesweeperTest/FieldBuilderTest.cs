using System.Collections.Generic;
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
            var fieldCreator = new FieldCreator();
            Assert.Null(fieldCreator.ReadField("00"));
        }
    }

    public class FieldCreator
    {
        public Field ReadField(string input)
        {
            var lineParser = new LineParser();
            var (x,y) = lineParser.GetSize(input);
            if (x == 0 || y == 0)
            {
                return null;
            }

            return new Field();
        }
    }

    public class Field
    {
    }
}