using System.IO;

namespace MinesweeperKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("input.txt");
            FieldParser fieldParser = new FieldParser(streamReader);
            fieldParser.CreateInputField();
            fieldParser.GetInputField();
        }
    }
}