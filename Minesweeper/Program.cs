﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputReader = new InputReader(); 
            var input = inputReader.ReadFile("/Users/cindy.cai/Desktop/RiderProjects/MinesweeperKata/input.txt");
            var fieldCreator = new FieldCreator();
            fieldCreator.ReadAllFields(input);
            var hintFieldCalculator = new HintFieldCalculator();
            hintFieldCalculator.CalculateAllFieldsHints(fieldCreator.AllFields);
            var outputWriter = new OutputWriter();
            outputWriter.WriteOutput(hintFieldCalculator.AllFieldsHints,fieldCreator.AllFields);
        }
    }

    internal class OutputWriter
    {
        public  void WriteOutput(IEnumerable<string[,]> calculatedArray, List<Field> fields)
        {
            var counter = 1;
            var zippedFields = fields.Zip(calculatedArray, (field, hint) => new {field, hint});
            foreach (var minesweeperField in zippedFields)
            {
                Console.WriteLine("\nField #" + counter);
                
                for (var i = 0; i < minesweeperField.field.Row; i++)
                {
                    for (var j = 0; j < minesweeperField.field.Col; j++)
                    {
                        Console.Write(minesweeperField.hint[i,j]);
                    }
                    Console.Write("\n");
                }
                counter++;
            }

        }
    }
}