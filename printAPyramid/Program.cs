using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printAPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CODE: Prints a pyramid
            byte baseStarNum = 9; // Pyramid base level star count (preferably odd)
            byte currLvlStarNum = baseStarNum;
            byte lvlNum = 1; // Pyramid level count
            // Find number of levels pyramid will have
            while (currLvlStarNum != 1)
            {
                lvlNum++;
                currLvlStarNum -= 2;
            }
            byte baseColNum = (byte)((baseStarNum + 1) / 2); // Guaranteed number of columns in every row at least
            for (byte row = 0; row < lvlNum; row++)
            {
                for (byte column = 0; column < baseColNum + row; column++)
                {
                    byte minRange = (byte)(baseColNum - row);
                    //byte maxRange = (byte)(baseColNum + row + 1);
                    if (column >= minRange - 1 /*&& column < maxRange*/)
                    {
                        Console.Write('*');
                        continue;
                    }
                    Console.Write(' ');
                }
                Console.WriteLine(); // Print on a new row
            }
            // CODE END

            Console.ReadKey();
        }
    }
}
