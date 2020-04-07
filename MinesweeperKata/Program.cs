
namespace MinesweeperKata
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var fr = new FileReader();
            var file = fr.ReadFile("/Users/cindy.cai/RiderProjects/MinesweeperKata/input.txt");
            var fieldBuilder = new FieldBuilder();
            var allFields = fieldBuilder.ReadAllFields(file);
            var hintFieldCalculator = new HintFieldCalculator();
            var calculatedFields = hintFieldCalculator.CalculateAllFields(allFields);
            var outputWriter = new OutputWriter();
            OutputWriter.WriteOutput(calculatedFields, allFields);
        }
    }
}