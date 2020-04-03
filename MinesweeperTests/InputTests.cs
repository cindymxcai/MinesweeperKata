using System.Collections.Generic;
using System.IO;
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
            var createdField = inputReader.ReadField(valueArray);
            Assert.Equal( new List<CellType>(){CellType.Empty,CellType.Mine}, createdField.GetRow(0));
            Assert.Equal( new List<CellType>(){CellType.Mine,CellType.Mine}, createdField.GetRow(1));
        }
        //test input 00 (for read field)
        //test read all fields (list of fields)
        [Fact]
        public void StopSettingRowsWhenZeroRead()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader(new[]{"33",".*.", "00", ".**", "..."});
            var valueArray = fileReader.ReadFile();
            var createdField = inputReader.ReadField(valueArray);
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Mine,CellType.Empty}, createdField.GetRow(0));
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Empty, CellType.Empty}, createdField.GetRow(2));
        }

        [Fact]
        public void SetFieldFromReadFile()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader();
            var valueArray = fileReader.ReadFile("/Users/cindy.cai/RiderProjects/MinesweeperKata/input.txt");
            var createdField = inputReader.ReadField(valueArray);
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Empty,CellType.Empty}, createdField.GetRow(0));
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Empty,CellType.Empty}, createdField.GetRow(1));
            Assert.Equal(new List<CellType>(){CellType.Mine,CellType.Empty,CellType.Empty}, createdField.GetRow(2));
        }
        [Fact]
        public void MakeNewFieldWhenReadNewSize()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader(new[]{"33",".*.", ".**", "...", "22", ".*", ".."});
            var valueArray = fileReader.ReadFile();
            var createdField = inputReader.ReadField(valueArray);
            //created field becomes 2x2 field, where does 3x3 field go???
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Mine}, createdField.GetRow(0));
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Empty}, createdField.GetRow(1));
        }

        [Fact]
        public void ReadAllFieldsShouldReturnManyFields()
        {
            var inputReader = new InputReader();
            var fileReader = new TestFileReader(new[]{"33",".*.", ".**", "...", "22", ".*", "..","00"});
            var valueArray = fileReader.ReadFile();
            var createdField = inputReader.ReadField(valueArray);
            //CREATES ONE EMPTY FIELD IN LIST OF FIELDS WHEN 33 PARSED
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Mine, CellType.Empty}, inputReader.AllFields[1].GetRow(0));
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Mine}, inputReader.AllFields[2].GetRow(0));
        }

    
        
        
        private class TestFileReader : IFileReader
        {
            private  string[] _stringArray;

            public TestFileReader(string[] stringArray)
            {
                _stringArray = stringArray;
            }

            public TestFileReader()
            {
            }
            
            public string[] ReadFile(string fileName)
            {
                return _stringArray = File.ReadAllLines(fileName);
            }

            public string[] ReadFile()
            {
                return _stringArray;
            }
        }
    }
}