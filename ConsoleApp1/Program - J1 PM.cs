using System.Collections;

namespace ConsoleApp1.J1PM
{
    internal class ProgramJ1PM
    {
        static void MainJ1PM(string[] args)
        {
            //int[] numbers = { 9, 6, 8, 3, 4, 7, 1, 2, 5, 0 };
            Random rand = new Random((int)DateTimeOffset.Now.ToUnixTimeMilliseconds());
            int[] numbers =
                new int[int.Parse(Console.ReadLine())]
                .Select(x => rand.Next(0, 100))
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));

            BubbleSort(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        static void BubbleSort(int[] numbers)
        {
            for (int i = numbers.Length; i > 1; i--)
                for (int j = 0; j < i - 1; j++)
                    if (numbers[j] > numbers[j + 1])
                        (numbers[j], numbers[j + 1]) = (numbers[j+1], numbers[j]);
        }
    }
}
