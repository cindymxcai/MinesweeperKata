using System.Collections.Generic;

namespace Minesweeper
{
    public class FieldCreator
    {

        public List<Field> ReadAllFields(string[] input)
        {
            var index = 0;
            var allFields = new List<Field>();
            while (TryReadField(input, index, out var currentField))
            {
                allFields.Add(currentField);
                index += currentField.Row + 1;
            }

            return allFields;
        }

        public static bool TryReadField(string[] input, int index, out Field result)
        {
            var (row, col) = LineParser.GetSize(input[index]);
            if (row == 0 || col == 0)
            {
                result = null;
                return false;
            }

            index++;
            var createdField = new Field(row, col);
            for (var currentRow = 0; currentRow < row; currentRow++)
            {
                createdField.SetRow(currentRow, LineParser.GetFieldRow(input[index]));
                index++;
            }

            result = createdField;
            return true;
        }
    }
}