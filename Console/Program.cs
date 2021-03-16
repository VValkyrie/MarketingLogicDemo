using Calculator;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProcessor manager = new();
            manager.Process("input.txt", 3);
        }
    }
}
