using System;
using System.Collections.Generic;
using MinesweeperKata;
using Xunit;
using Xunit.Abstractions;

namespace MinesweeperTests
{
    public class FieldTests
    {
        
        [Fact]
        public void SetFieldSize()
        {
            var field = new Field(3,5);
            Assert.Equal(new List<CellType>(){CellType.Empty, CellType.Empty, CellType.Empty}, field.GetRow(4) );
        }
        //field x = 3, y = 5
        //all cells empty
        //

        [Fact]
        public void SetRowTest()
        {
            var field = new Field(3,5);
            var row = new List<CellType>() {CellType.Empty, CellType.Empty, CellType.Mine};
            field.SetRow(1, row);
            Assert.Equal(row,field.GetRow(1));
        }
        //write failing test throw exception

        [Fact]
        public void SetField()
        {
            
        }
    }
}