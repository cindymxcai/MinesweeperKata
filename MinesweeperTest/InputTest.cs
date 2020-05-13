using Xunit;

namespace MinesweeperTest
{
    public class InputTest
    {
        [Fact]
        public void ShouldMakeFieldFromFile()
        {
            var mock = new Mock<IInputReader>();
            mock.setUp(input => input.ReadFile()).Returns(new[] {"22", "..", ".*", "00"});
            var valueArray = mock.ReadFile();
            var createdField = fieldBuilder.ReadField(valueArray,0);
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Empty}, createdField.GetRow(0));
            Assert.Equal(new List<CellType>(){CellType.Empty,CellType.Mine}, createdField.GetRow(1));
        }
    }
}