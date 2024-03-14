namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file name: ");
            var file = Console.ReadLine();

            var startRange = GetNumFormConsole("Enter start of range: ");
            var endRange = GetNumFormConsole("Enter end of range: ");

            Parallel.Invoke( () => { WriteMultiplyTable(startRange, endRange, file); });
        }

        private static int GetNumFormConsole(string request)
        {
            int num;
            do {
                Console.WriteLine(request);
            } while(!int.TryParse(Console.ReadLine(), out num));
            return num;
        }

        private static void WriteMultiplyTable(int start, int end, string file)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    for (int i = start; i < end; i++)
                    {
                        Parallel.For(1, 11, j =>
                        {
                            writer.WriteLine($"{i}*{j} = {i * (j)}");
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
