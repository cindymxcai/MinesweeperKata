namespace Minesweeper
{
    public class FieldCreator
    {
        public Field ReadField(string [] input)
        {
            var lineParser = new LineParser();
            var (row,col) = lineParser.GetSize(input[0]);
            if (row == 0 || col == 0)
            {
                return null;
            }

            var createdField = new Field(row, col);

            var index = 1;

            for (var currentRow = 0; currentRow < row; currentRow++)
            {
                createdField.SetRow(currentRow, lineParser.GetFieldRow(input[index]));
                index++;
            }
            return createdField;

        }
    }
}