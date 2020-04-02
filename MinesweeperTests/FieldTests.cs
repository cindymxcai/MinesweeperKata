using System.Collections.Generic;
using MinesweeperKata;
using Xunit;

namespace MinesweeperTests
{
    public class FieldTests
    {
        
        [Fact]
        public void SetFieldSizeShouldInitializeEmptyFieldOfGivenSize()
        {
            var field = new Field(3,1);
            Assert.Equal(new List<CellType>(){CellType.Empty, CellType.Empty, CellType.Empty}, field.GetRow(0) );
        }

        [Fact]
        public void SetRowTestShouldReturnListOfRowCells()
        {
            var field = new Field(3,1);
            var row = new List<CellType>() {CellType.Empty, CellType.Empty, CellType.Mine};
            field.SetRow(0, row);
            Assert.Equal(row,field.GetRow(0));
        }

        //not throwing exception properly?
        
        /*[Theory]
        [InlineData(1,5, CellType.Empty, CellType.Empty)]
        public void SetRowWithInvalidInputShouldThrowException(int row, int col, CellType cell1, CellType cell2)
        {
            var field = new Field(col,row);
            var rowInput = new List<CellType>(){cell1, cell2};
            field.SetRow(0, rowInput);
            Assert.Throws<RowSetterException>(() => field.GetRow(1));
        }*/
        
    }

    
}