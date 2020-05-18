using System.Collections.Generic;
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
           var allFields = fieldCreator.ReadFields(new[] {"11", ".", "22", "..", "*.", "00"});
            Assert.Equal(2, allFields.Count);
        }
    }
}