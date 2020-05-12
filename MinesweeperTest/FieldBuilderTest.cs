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

        [Theory]
        [InlineData("33", 3, 3)]
        [InlineData("15", 1, 5)]
        [InlineData("21", 2, 1)]
        [InlineData("59", 5, 9)]

        public void FieldShouldBeMadeOfCorrectSizeGivenValidSize(string input, int expectedRowSize, int expectedColsize)
        {
            var fieldCreator = new FieldCreator();
            var createdField = fieldCreator.ReadField(input);
            Assert.Equal(expectedRowSize, createdField.Row);
            Assert.Equal(expectedColsize, createdField.Col);
        }
    }

    public class FieldCreator
    {
        public Field ReadField(string input)
        {
            var lineParser = new LineParser();
            var (row,col) = lineParser.GetSize(input);
            if (row == 0 || col == 0)
            {
                return null;
            }
            else
            {
                var createdField = new Field(row, col);
                return createdField;
            }

        }
    }

    public class Field
    {
        public readonly int Row;
        public readonly int Col;

        public Field(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}