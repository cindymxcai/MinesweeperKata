using System.Collections.Generic;

namespace MinesweeperKata
{
    public class InputReader : IInputReader
    {
        public readonly List<Field> AllFields = new List<Field>();


        public void ReadAllFields(Field createdField)
        {
            AllFields.Add(createdField);
        }

        public Field readField(string[] valueArray)
        {
            var lineParser = new LineParser();
            var index = 0;
            Field createdField = null;
            
            foreach (var line in valueArray)
            {
                if (int.TryParse(line, out _))
                {
                    if (line == "00")
                    {
                        ReadAllFields(createdField);
                        break;
                    }
                    else
                    {
                        index = 0;
                        var (row, col) = lineParser.GetSize(line);
                        ReadAllFields(createdField);
                        createdField = new Field(col, row);
                    }
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