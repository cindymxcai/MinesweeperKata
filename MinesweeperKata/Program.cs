using System.IO;

namespace MinesweeperKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fr = new FileReader();
            fr.ReadFile("name");
        }
    }
}