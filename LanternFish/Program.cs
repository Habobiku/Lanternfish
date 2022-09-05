using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lanternFish = new List<int> {3, 5, 4, 1, 2, 1, 5, 5, 1, 1, 1, 1, 4, 1, 4, 5, 4, 5, 1, 3, 1, 1, 1, 4, 1, 1, 3, 1, 1, 5, 3, 1, 1, 3, 1, 3, 1, 1, 1, 4, 1, 2, 5, 3, 1, 4, 2, 3, 1, 1, 2, 1, 1, 1, 4, 1, 1, 1, 1, 2, 1, 1, 1, 3, 1, 1, 4, 1, 4, 1, 5, 1, 4, 2, 1, 1, 5, 4, 4, 4, 1, 4, 1, 1, 1, 1, 3, 1, 5, 1, 4, 5, 3, 1, 4, 1, 5, 2, 2, 5, 1, 3, 2, 2, 5, 4, 2, 3, 4, 1, 2, 1, 1, 2, 1, 1, 5, 4, 1, 1, 1, 1, 3, 1, 5, 4, 1, 5, 1, 1, 4, 3, 4, 3, 1, 5, 1, 1, 2, 1, 1, 5, 3, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 2, 2, 5, 5, 1, 2, 1, 2, 1, 1, 5, 1, 3, 1, 5, 2, 1, 4, 1, 5, 3, 1, 1, 1, 2, 1, 3, 1, 4, 4, 1, 1, 5, 1, 1, 4, 1, 4, 2, 3, 5, 2, 5, 1, 3, 1, 2, 1, 4, 1, 1, 1, 1, 2, 1, 4, 1, 3, 4, 1, 1, 1, 1, 1, 1, 1, 2, 1, 5, 1, 1, 1, 1, 2, 3, 1, 1, 2, 3, 1, 1, 3, 1, 1, 3, 1, 3, 1, 3, 3, 1, 1, 2, 1, 3, 2, 3, 1, 1, 3, 5, 1, 1, 5, 5, 1, 2, 1, 2, 2, 1, 1, 1, 5, 3, 1, 1, 3, 5, 1, 3, 1, 5, 3, 4, 2, 3, 2, 1, 3, 1, 1, 3, 4, 2, 1, 1, 3, 1, 1, 1, 1, 1, 1 };



            Console.WriteLine("The count of lanternfish after 80 days is " + Puzzle1(lanternFish));
            Puzzle2(lanternFish);
        



            void Puzzle2(List<int> lanternFish)
            {

                Dictionary<long, long> fishDict = new Dictionary<long, long>();
                for (int i = 0; i < lanternFish.Count; i++)
                {
                    AddToDict(fishDict, lanternFish[i], 1);

                }

                for (int days = 1; days <= 256; days++)
                {
                    Dictionary<long, long> nextDayDict = new Dictionary<long, long>();

                    foreach (long dayToReproduce in fishDict.Keys.ToArray())
                    {
                        // Get amount of fish in age group
                        long amountOfFishThisAge = fishDict[dayToReproduce];
                        // Get next age
                        long nextAge = dayToReproduce - 1;

                        // If next age just grows old
                        if (nextAge >= 0)
                        {
                            // Grow old
                            AddToDict(nextDayDict, nextAge, amountOfFishThisAge);
                        }
                        else
                        {
                            // Reproduce
                            AddToDict(nextDayDict, 8, amountOfFishThisAge);
                            AddToDict(nextDayDict, 6, amountOfFishThisAge);
                        }
                    }

                    fishDict = nextDayDict;
                    long sum = 0;
                    foreach (long amountOfFish in fishDict.Values)
                    {
                        sum += amountOfFish;
                    }
                    Console.WriteLine("Fish after days: " + sum);
                }

            }


            int Puzzle1(List<int> laternFish)
            {
                int days = 80;
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
                return lanternFish.Count;
            }
           

            
             void AddToDict(Dictionary<long, long> dict, long key, long amount)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] += amount;
                }
                else
                {
                    dict.Add(key, amount);
                }
            }


            

        }
    }
}

