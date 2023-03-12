using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monthsOfTheYear
{
    enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            byte num = 0;
            Console.WriteLine("Enter a number between 1 and 12: ");
            do
            {
                num = Convert.ToByte(Console.ReadLine());
            }
            while (num < 1 || num > 12);
            Months month = (Months)num;
            switch (month)
            {
                case Months.January:
                    Console.WriteLine(Months.January);
                    break;
                case Months.February:
                    Console.WriteLine(Months.February);
                    break;
                case Months.March:
                    Console.WriteLine(Months.March);
                    break;
                case Months.April:
                    Console.WriteLine(Months.April);
                    break;
                case Months.May:
                    Console.WriteLine(Months.May);
                    break;
                case Months.June:
                    Console.WriteLine(Months.June);
                    break;
                case Months.July:
                    Console.WriteLine(Months.July);
                    break;
                case Months.August:
                    Console.WriteLine(Months.August);
                    break;
                case Months.September:
                    Console.WriteLine(Months.September);
                    break;
                case Months.October:
                    Console.WriteLine(Months.October);
                    break;
                case Months.November:
                    Console.WriteLine(Months.November);
                    break;
                case Months.December:
                    Console.WriteLine(Months.December);
                    break;
                default:
                    Console.WriteLine("Invalid month");
                    break;
            }
            Console.ReadKey();
        }
    }
}
