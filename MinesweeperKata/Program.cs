using System;
using System.IO;

namespace MinesweeperKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            InputReader  ip = new InputReader();
            var fr = new FileReader();
            var valueArray = fr.ReadFile("/Users/cindy.cai/RiderProjects/MinesweeperKata/input.txt");
            var createdField = ip.readField(valueArray);
            ip.ReadAllFields(createdField);

        }
    }
}