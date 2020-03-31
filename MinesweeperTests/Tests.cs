using System.IO;
using System.Text;
using MinesweeperKata;
using Xunit;

namespace MinesweeperTests
{
    public class Tests
    {
        [Fact]
        public void CreateFileTest()
        {
            using (var sw = new StreamWriter("input.txt"))
            {
                sw.Write("");
                sw.Close();
            }
            
        }

        [Fact]
        public void ReadRowsAndCols()
        {
            using (var sw = new StreamWriter("input.txt"))
            {
                sw.Write("33");
                sw.Close();
            }

            var streamReader = new StreamReader("input.txt");
            var minesweeper = new FieldParser(streamReader);
            streamReader.Close();
            Assert.Equal(3, minesweeper.GetRows()); 
            Assert.Equal(3, minesweeper.GetCols()); 
        }

        [Fact]
        public void EmptyGrid()
        {
            using (var sw = new StreamWriter("input.txt"))
            {
                sw.Write("33\n...\n...\n...");
                sw.Close();
            }

            var streamReader = new StreamReader("input.txt");
            var minesweeper = new FieldParser(streamReader);
            streamReader.Close();
            minesweeper.CreateInputField();
            Assert.Equal("...\n...\n...\n", minesweeper.GetInputField());

        }
    }
}