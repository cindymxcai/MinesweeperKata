using System;
using Xunit;

namespace MinesweeperTest
{
    public class FieldTest
    {
        [Fact]
        public void SetFieldSizeShouldInitializeEmptyFieldOfGivenSize()
        {
            var field = new Field(3,1);
            Assert.Equal(new List<CellType>(){CellType.Empty, CellType.Empty, CellType.Empty}, field.GetRow(0) );
        }
    }
}