using System.Collections.Generic;

namespace Minesweeper
{
    public class FieldCreator
    {
        public FieldCreator()
        {
            AllFields = new List<Field>();
        }

        public List<Field> AllFields { get; }

        public void ReadAllFields(string[] input)
        {
            var index = 0;
            var currentField = ReadField(input, index);
            
            while (currentField != null)
            {
                AllFields.Add(currentField);
                index += currentField.Row + 1;
                currentField = ReadField(input, index);
            }
        }

        public Field ReadField(string[] input, int index)
        {
            var lineParser = new LineParser();
            var (row, col) = lineParser.GetSize(input[index]);
            if (row == 0 || col == 0)
            {
                return null;
            }

            index++;
            var createdField = new Field(row, col);
            for (var currentRow = 0; currentRow < row; currentRow++)
            {
                createdField.SetRow(currentRow, lineParser.GetFieldRow(input[index]));
                index++;
            }

            return createdField;
        }
    }
}