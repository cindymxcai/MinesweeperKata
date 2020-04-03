using System.Collections.Generic;

namespace MinesweeperKata
{
    public class InputReader : IInputReader
    {


        public List<Field> ReadAllFields(string [] valueArray)
        {
            var index = 0;
            var allFields = new List<Field>();
            var currentField = ReadField(valueArray, index);
            if (currentField == null)
            {
                return allFields;
            }
            
            allFields.Add(currentField);
            index += currentField.numberOfRows+1;
            
            while (currentField != null)
            {
                currentField = ReadField(valueArray,  index);
                if (currentField == null)
                {
                    return allFields;
                }
                allFields.Add(currentField);
                index += currentField.numberOfRows+1;
            }

            return allFields;
        }

        public Field ReadField(string[] valueArray, int index )
        {
            var lineParser = new LineParser();
            Field createdField = null;

            var (row, col) = lineParser.GetSize(valueArray[index]);
            if ((row, col) == (0, 0))
            {
                return null;
            }
            index++;
            createdField = new Field(col, row);
            for (var i = 0; i < row; i++)
            {
                createdField.SetRow(i, lineParser.GetFieldRow(valueArray[index]));
                index++;
            }

            return createdField;
        }
    }
}