using System.Collections.Generic;
using Minesweeper;
using Moq;
using Xunit;

namespace MinesweeperTest
{
    public class InputTest
    {
        [Fact]
        public void ShouldMakeFieldFromFile()
        {
            var mock = new Mock<IInputReader>();
            mock.Setup(input => input.ReadFile("")).Returns(new[] {"22", "..", ".*", "00"});
            var isFieldCreated = FieldCreator.TryReadField(mock.Object.ReadFile(""),0, out var createdField);
            Assert.Equal(new [] {"22","..",".*","00"},mock.Object.ReadFile(""));
            Assert.True(isFieldCreated);
            Assert.Equal(new List<CellType>{CellType.Empty,CellType.Empty}, createdField.GetRow(0));
            Assert.Equal(new List<CellType>{CellType.Empty,CellType.Mine}, createdField.GetRow(1));
        }
        
    }
}