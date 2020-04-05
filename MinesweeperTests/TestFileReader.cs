using System.IO;
using MinesweeperKata;

namespace MinesweeperTests
{
    public class TestFileReader : IFileReader
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