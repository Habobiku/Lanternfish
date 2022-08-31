using System;
using System.Collections.Generic;

namespace Lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = 80;
            List<int> lanternFish = new List<int> { 3, 4, 3, 1, 2 };
            for (int i = 0; i < days; i++)
            {
                List<int> copyFish = new List<int>();
                foreach (int fish in lanternFish)
                {
                    if (fish == 0)
                    {
                        copyFish.Add(8);
                        copyFish.Add(6);
                    }
                    else
                    {
                        copyFish.Add(fish - 1);
                    }
                }
                lanternFish = copyFish;
            }

            Console.WriteLine("The count of lanternfish after 80 days is " + lanternFish.Count);

        }
    }
}