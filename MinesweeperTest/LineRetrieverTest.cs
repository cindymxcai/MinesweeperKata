using System;
using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class LineRetrieverTest
    {
        [Fact]
        public void ShouldReturnLinesInOrder()
        {
            var lineRetriever = new LineRetriever( new []{"22","..","*.", "00"});
            var line = lineRetriever.GetNextLine();
            Assert.Equal("22", line);
            line = lineRetriever.GetNextLine();
            Assert.Equal("..", line);
        }

        [Fact]
        public void ShouldThrowExceptionIfOutOfLines()
        {
            var lineRetriever = new LineRetriever( new []{"00"});
            var line = lineRetriever.GetNextLine();
            Assert.Equal("00", line);
            Assert.Throws<IndexOutOfRangeException>(() => lineRetriever.GetNextLine());
        }

        [Fact]
        public void ShouldThrowArgumentExceptionIfPassedNull()
        {
            Assert.Throws<ArgumentException>(()=> new LineRetriever( null));
        }
    }
    
}