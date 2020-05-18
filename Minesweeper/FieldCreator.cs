using System.Collections.Generic;

namespace Minesweeper
{
    public class FieldCreator
    {
        public List<Field> ReadFields(string[] input)
        {
            var fieldData = new List<List<CellType>>();
            var fields =  CreateInitialFields(input, fieldData);
            PopulateFields(fields, fieldData);
            return fields;
        }

        private static void PopulateFields(List<Field> allFields, IReadOnlyList<List<CellType>> fieldData)
        {
            var index = 0;
            foreach (var field in allFields)
            {
                for (var i = 0; i < field.Row; i++)
                {
                    field.SetRow(i, fieldData[index]);
                    index++;
                }
            }
        }

        private List<Field> CreateInitialFields(IReadOnlyList<string> input, ICollection<List<CellType>> fieldData)
        {
            var index = 0;
            var allFields = new List<Field>();
            while (true)
            {
                if (int.TryParse(input[index], out _))
                {
                    var (row, col) = LineParser.GetSize(input[index]);
                    if (row == 0 || col == 0)
                    {
                        break;
                    }
                    
                    allFields.Add(new Field(row, col));
                }
                else
                {
                    fieldData.Add(LineParser.GetFieldRow(input[index]));
                }

                index++;
            }
            return allFields;
        }

        

        /*public List<Field> ReadAllFields(string[] input)
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

            var createdField = new Field(row, col);
            index++;
            for (var currentRow = 0; currentRow < row; currentRow++)
            {
                createdField.SetRow(currentRow, LineParser.GetFieldRow(input[index]));
                index++;
            }

            result = createdField;
            return true;
        }*/
    }
}