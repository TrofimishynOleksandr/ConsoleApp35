namespace ConsoleApp35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            do {
                Console.Write("Enter number to count it's factorial: ");
            } while(!int.TryParse(Console.ReadLine(), out number));

            Parallel.Invoke(() => 
            { 
                var f = Factorial(number);
                Console.WriteLine($"Factorial of {number} is {f}");
                Parallel.Invoke(
                    () => { var count = CountDigits(f); Console.WriteLine($"Digits in this num: {count}"); },
                    () => { var sum = CountDigitsSum(f); Console.WriteLine($"Sum of digits in this num: {sum}"); }
                );
            });
        }

        private static int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        private static int CountDigits(int num)
        {
            int count = 0;
            while (num > 0)
            {
                num = num / 10;
                count++;
            }
            return count;
        }

        private static int CountDigitsSum(int num)
        {
            int sum = 0;
            while(num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
