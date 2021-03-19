using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator
{
    public class DataProcessor
    {
        private Queue<byte> queue;
        
        public void Process(string filename, int windowSize)
        {
            if (windowSize % 2 == 0)
                throw new NotSupportedException("Window size must be odd");

            int startCount = windowSize / 2;

            queue = new Queue<byte>(GetZeroEnumerator(startCount));


            using StreamReader sr = new(filename);

            string line;
            int endCount = windowSize / 2;

            while (!sr.EndOfStream || endCount > 0)
            {
                if (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    var strings = line.Split(" ");

                    OperationType type = (OperationType) byte.Parse(strings[0]);


                    byte[] args = new byte[strings.Length - 1];

                    for (int i = 0; i < args.Length; i++)
                        args[i] = byte.Parse(strings[i + 1]);

                    byte result = Calculator.Calculate(type, args);

                    queue.Enqueue(result);
                }
                else
                {
                    queue.Enqueue(0);
                    endCount--;
                }

                if (queue.Count > windowSize)
                    queue.Dequeue();

                if (startCount > 0)
                    startCount--;
                else
                {
                    foreach (byte a in queue)
                        Console.Write(a + " ");
                    Console.WriteLine();

                    byte median = Calculator.Median(queue.ToArray());
                    Console.WriteLine(median);
                    Console.WriteLine();
                }
            }
        }

        private static IEnumerable<byte> GetZeroEnumerator(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return 0;
            }
        }
    }
}
