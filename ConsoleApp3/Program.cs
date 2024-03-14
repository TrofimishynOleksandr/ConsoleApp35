using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file name: ");
            var file = Console.ReadLine();

            try
            {
                var text = File.ReadAllText(file);
                Regex regex = new Regex(@"(?<!\d)\d+(?!\d)");
                MatchCollection matches = regex.Matches(text);
                List<int> numbers = new List<int>();
                foreach (Match match in matches)
                {
                    int num = int.Parse(match.Value);
                    numbers.Add(num);
                    Console.Write($"{num} ");
                }

                var sum = numbers.AsParallel().Sum();
                var max = numbers.AsParallel().Max();
                var min = numbers.AsParallel().Min();

                Console.WriteLine();
                Console.WriteLine($"Sum: {sum}\n" +
                    $"Max: {max}\n" +
                    $"Min: {min}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
