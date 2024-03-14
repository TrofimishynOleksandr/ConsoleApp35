using System.Text.RegularExpressions;

namespace ConsoleApp2
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
                    numbers.Add(int.Parse(match.Value));
                }
                Parallel.ForEach(numbers, num =>
                {
                    var f = Factorial(num);
                    Console.WriteLine($"Factorial of {num} is {f}");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        private static int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}
