using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class OutputWriter
    {
        public static void WriteOutput(IEnumerable<string[,]> calculatedArray, List<Field> fields)
        {
            var counter = 1;
            var zippedFields = fields.Zip(calculatedArray, (field, strings) => new {field, strings});
            foreach (var field in zippedFields)
            {
                Console.WriteLine("\nField #" + counter);
                
                for (var i = 0; i < field.field.NumberOfRows; i++)
                {
                    for (var j = 0; j < field.field.NumberOfCols; j++)
                    {
                        Console.Write(field.strings[i,j]);
                    }
                    Console.Write("\n");
                }

                counter++;
            }

        }
    }
}
