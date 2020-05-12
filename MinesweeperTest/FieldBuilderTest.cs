using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class FieldBuilderTest
    {

        [Fact]
        public void FieldCreatorShouldReturnNullIfRowOrColAre0()
        {
            var fieldCreator = new FieldCreator();
            Assert.Null(fieldCreator.ReadField("00"));
        }

        [Fact]
        public void FieldShouldBeMadeOfCorrectSizeGivenValidSize()
        {
            var fieldCreator = new FieldCreator();
            Assert.Equal(3, fieldCreator.ReadField("33").NumberOfRows);
            Assert.Equal(3, fieldCreator.ReadField("33").NumberOfCols);
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