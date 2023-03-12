using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(1));
            Console.WriteLine(Fibonacci(2));
            Console.WriteLine(Fibonacci(3));
            Console.WriteLine(Fibonacci(4));
            Console.WriteLine(Fibonacci(5));
            Console.WriteLine(Fibonacci(6));
            Console.WriteLine(Fibonacci(7));
            Console.WriteLine(Fibonacci(8));
            Console.WriteLine(Fibonacci(10));
            Console.ReadKey();
        }

        /// <summary>
        /// Fibonacci Sequence
        /// </summary>
        /// <param name="num">What number in fibonacci sequence to return</param>
        /// <returns>The "num" number in fibonacci sequence</returns>
        static ulong Fibonacci(ulong num)
        {
            if (num == 2 || num == 1)
            {
                return 1;
            }
            return Fibonacci(num - 1) + Fibonacci(num - 2);
        }
    }
}
