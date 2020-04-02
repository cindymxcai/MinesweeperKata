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
            var valueArray = fileReader.ReadFile("ignored");
            var createdField = inputReader.readField(valueArray);
            Assert.Equal( new List<CellType>(){CellType.Empty,CellType.Mine}, createdField.GetRow(0));
            Assert.Equal( new List<CellType>(){CellType.Mine,CellType.Mine}, createdField.GetRow(1));
        }
        //test input 00 (for read field)
        //test read all fields (list of fields)
        [Fact]
        public void StopSettingRowsWhenZeroRead()
        {
            var inputReader = new InputReader();
            var fileReader = new FileReader();
            
        }
        private class TestFileReader : IFileReader
        {
            private readonly string[] _stringArray;

            public TestFileReader(string[] stringArray)
            {
                _stringArray = stringArray;
            }
            public string[] ReadFile(string fileName)
            {
                return _stringArray;
            }
        }
    }
}