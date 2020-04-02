using System.Collections.Generic;

namespace MinesweeperKata
{
    public class InputReader : IInputReader
    {

        public List<Field> ReadAllFields(string[] valueArray)
        {
            var allFields = new List<Field>();
            return allFields;
        }
        public Field readField(string[] valueArray)
        {
            var lineParser = new LineParser();
            var number = 0;
            var index = 0;
            bool readingSize = true;
            Field createdField = null;
            
            foreach (var line in valueArray)
            {
                if (readingSize) 
                {
                    var (row, col) = lineParser.GetSize(line);
                    createdField = new Field(col,row);
                    readingSize = false;
                }
                else
                {
                    createdField?.SetRow(index, lineParser.GetFieldRow(line));
                    index++;
                }
            }

            return createdField;
        }
    }
}