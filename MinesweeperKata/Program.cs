using System;

namespace MinesweeperKata
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var fr = new FileReader();
            var file = fr.ReadFile("/Users/cindy.cai/RiderProjects/MinesweeperKata/input.txt");
            var fieldBuilder = new FieldBuilder();
            var createdField = fieldBuilder.ReadField(file,0);
            var hintFieldCalculator = new HintFieldCalculator();
            var hintArray = hintFieldCalculator.ConvertToArray(createdField);
            var calculatedField = hintFieldCalculator.CalculateNumberOfSurroundingMines(hintArray, createdField);
            var outputWriter = new OutputWriter();
            outputWriter.WriteOutput(calculatedField);

        }
    }
}