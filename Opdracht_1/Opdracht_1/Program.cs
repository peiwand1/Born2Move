using Sort_opdracht;
using System.Diagnostics;

namespace Sort_Opdracht
{
    class Program
    {
        static void Main(string[] args)
        {
            // user input for how big the random number list should be, default to 10
            Console.WriteLine("How many numbers to generate:");
            int count;
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out count)) count = 10;

            //List<int> nrList = getRandomNumbers(-99, 99, count);
            Console.WriteLine("\n\nSorting...\n");


            // test each sorting algorithm x times and print time taken
            Stopwatch stopWatch = new Stopwatch();
            int testAmount = 100;
            ShiftHighestSort shiftHighestSort = new ShiftHighestSort();
            KeepListSorted keepListSorted = new KeepListSorted();
            RotateSort rotateSort = new RotateSort();

            ////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < testAmount; i++)
            {
                List<int> nrList = getRandomNumbers(-99, 99, count); // generate a new random list each time

                stopWatch.Start(); // only time the sort function
                //List<int> shiftSorted = 
                shiftHighestSort.Sort(nrList);
                stopWatch.Stop();
            }

            Console.WriteLine("ShiftHighestSort:");
            Console.WriteLine("Runtime " + stopWatch.Elapsed.TotalMilliseconds + " ms for " + testAmount + " sorts");
            Console.WriteLine("Avg " + stopWatch.Elapsed.TotalMilliseconds / testAmount + " ms");
            Console.WriteLine();
            stopWatch.Reset();

            ////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < testAmount; i++)
            {
                List<int> nrList = getRandomNumbers(-99, 99, count);

                stopWatch.Start();
                //List<int> keepSorted = 
                keepListSorted.Sort(nrList);
                stopWatch.Stop();
            }

            Console.WriteLine("KeepListSorted:");
            Console.WriteLine("Runtime " + stopWatch.Elapsed.TotalMilliseconds + " ms for " + testAmount + " sorts");
            Console.WriteLine("Avg " + stopWatch.Elapsed.TotalMilliseconds / testAmount + " ms");
            Console.WriteLine();
            stopWatch.Reset();

            ////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < testAmount; i++)
            {
                List<int> nrList = getRandomNumbers(-99, 99, count);

                stopWatch.Start();
                //List<int> rotateSorted = 
                rotateSort.Sort(nrList);
                stopWatch.Stop();
            }

            Console.WriteLine("RotateSort:");
            Console.WriteLine("Runtime " + stopWatch.Elapsed.TotalMilliseconds + " ms for " + testAmount + " sorts");
            Console.WriteLine("Avg " + stopWatch.Elapsed.TotalMilliseconds / testAmount + " ms");
            Console.WriteLine();
            stopWatch.Reset();

            //printList(rotateSorted);
            //Console.WriteLine(validateSort(nrList, count) ? "sort successful" : "sort unsuccessful");
        }

        static private List<int> getRandomNumbers(int lowerBound, int upperBound, int amount)
        {
            Random rnd = new Random();
            List<int> nrList = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                nrList.Add(rnd.Next(lowerBound, upperBound + 1));
                //Console.WriteLine(nrList[i]);
            }
            return nrList;
        }

        static private bool validateSort(List<int> nrList, int correctCount)
        {
            if (nrList.Count != correctCount) return false;

            for (int i = 0; i < nrList.Count - 1; i++)
            {
                if (nrList[i] > nrList[i + 1]) return false;
            }
            return true;
        }

        static private void printList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                if (i >= 200) break; // cap print at 200 values
            }
        }
    }
}