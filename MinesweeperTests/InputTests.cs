using System.Collections.Generic;
using MinesweeperKata;
using Xunit;

namespace MinesweeperTests
{
    public class InputTests
    {
        [Fact]
        public void SetRowsOfField()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader(new[]{"22", ".*", "**"});
            var valueArray = fileReader.ReadFile();
            var createdField = inputReader.ReadField(valueArray,0);
            Assert.Equal( new List<CellType>(){CellType.Empty,CellType.Mine}, createdField.GetRow(0));
            Assert.Equal( new List<CellType>(){CellType.Mine,CellType.Mine}, createdField.GetRow(1));
        }
     
        [Fact]
        public void StopSettingRowsWhenZeroRead()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader(new[]{ "00"});
            var valueArray = fileReader.ReadFile();
            var createdField = inputReader.ReadField(valueArray,0);
            Assert.Null( createdField);
        }

        [Fact]
        public void SetFieldFromReadFile()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader();
            var valueArray = fileReader.ReadFile("/Users/cindy.cai/RiderProjects/MinesweeperKata/input.txt");
            var createdField = inputReader.ReadField(valueArray,0);
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Empty,CellType.Empty}, createdField.GetRow(0));
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Empty,CellType.Empty}, createdField.GetRow(1));
            Assert.Equal(new List<CellType>(){CellType.Mine,CellType.Empty,CellType.Empty}, createdField.GetRow(2));
        }
        
        [Fact]
        public void MakeNewFieldWhenReadNewSize()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader(new[]{"33",".*.", ".**", "...", "22", ".*", "..","00"});
            var valueArray = fileReader.ReadFile();
            var createdFields = inputReader.ReadAllFields(valueArray);
            Assert.Equal(2, createdFields.Count );
        }

        [Fact]
        public void ReadAllFieldsShouldReturnManyFields()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader(new[] {"33", ".*.", ".**", "...", "22", ".*", "..", "00"});
            var valueArray = fileReader.ReadFile();
            var createdFields = inputReader.ReadAllFields(valueArray);
            Assert.Equal(new List<CellType>() {CellType.Empty, CellType.Mine, CellType.Empty},
                createdFields[0].GetRow(0));
            Assert.Equal(new List<CellType>() {CellType.Empty, CellType.Mine}, createdFields[1].GetRow(0));
        }
    }
}