using System.Collections.Generic;
using Minesweeper;
using Xunit;

namespace MinesweeperTest
{
    public class FieldBuilderTest
    {
        [Theory]
        [MemberData(nameof(InputDataWithZero))]
        public void FieldCreatorShouldReturnNullIfRowOrColAre0(string[] input)
        {
            Assert.Null(FieldCreator.ReadField(input, 0));
        }

        private static IEnumerable<object[]> InputDataWithZero()
        {
            var test1 = new[] {"03", "...", "...", "...", "00"};
            var test2 = new[] {"00", ".."};
            var test3 = new[] {"90"};
            yield return new object[] {test1};
            yield return new object[] {test2};
            yield return new object[] {test3};
        }

        [Theory]
        [MemberData(nameof(InputData))]
        public void FieldShouldBeMadeOfCorrectSizeGivenValidSize(string[] input, int expectedRowSize,
            int expectedColSize)
        {
            var createdField = FieldCreator.ReadField(input, 0);
            Assert.Equal(expectedRowSize, createdField.Row);
            Assert.Equal(expectedColSize, createdField.Col);
        }

        private static IEnumerable<object[]> InputData()
        {
            var test1 = new[] {"33", "...", "...", "...", "00"};
            var test2 = new[] {"15", ".....", "00"};
            var test3 = new[] {"21", ".", ".", "00"};
            var test4 = new[] {"59", ".........", ".........", ".........", ".........", ".........", "00"};
            yield return new object[] {test1, 3, 3};
            yield return new object[] {test2, 1, 5};
            yield return new object[] {test3, 2, 1};
            yield return new object[] {test4, 5, 9};
        }

        [Fact]
        public void FieldCreatorShouldThenPopulateFieldAfterCorrectSize()
        {
            var createdField = FieldCreator.ReadField(new[] {"22", "*.", "..", "00"}, 0);
            Assert.Equal(new List<CellType> {CellType.Mine, CellType.Empty}, createdField.GetRow(0));
        }

        [Fact]
        public void FieldCreatorShouldMakeNewFieldIfNumberRead()
        {
            var fieldCreator = new FieldCreator();
            fieldCreator.ReadAllFields(new[] {"11", ".", "22", "..", "*.", "00"});
            Assert.Equal(2, fieldCreator.AllFields.Count);
        }
    }
}