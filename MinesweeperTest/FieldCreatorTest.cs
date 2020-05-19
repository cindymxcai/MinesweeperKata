using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class FieldBuilderTest
    {

        [Fact]
        public void FieldCreatorShouldMakeNewFieldIfNumberRead()
        {
            var fieldCreator = new FieldCreator();
            var lineRetriever = new LineRetriever(new[] {"11", ".", "22", "..", "*.", "00"});
           var allFields = fieldCreator.ReadFields(lineRetriever);
            Assert.Equal(2, allFields.Count);
        }
    }
}