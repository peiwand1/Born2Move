using Sort_opdracht;

namespace Sort_Opdracht
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers to generate:");
            int count;
            string input = Console.ReadLine();
            if (!int.TryParse(input, out count))
            {
                count = 10;
            }
            List<int> nrList = getRandomNumbers(-99, 99, count);
            //List<int> nrList = new List<int>([10, 9, 8, 7, 6, 5, 4, 3, 2, 1]);
            Console.WriteLine("\n\nSorting...\n");

            //TODO test hoe lang deze erover doen met stopwatch

            //ShiftHighestSort shiftHighestSort = new ShiftHighestSort();
            //nrList = shiftHighestSort.Sort(nrList);

            //KeepListSorted keepListSorted = new KeepListSorted();
            //nrList = keepListSorted.Sort(nrList);

            RotateSort rotateSort = new RotateSort();
            nrList = rotateSort.Sort(nrList);

            for (int i = 0; i < nrList.Count; i++)
            {
                Console.WriteLine(nrList[i]);
                if (i >= 200) break;
            }

            Console.WriteLine(validateSort(nrList, count) ? "sort successful" : "sort unsuccessful");

        }

        static private List<int> getRandomNumbers(int lowerBound, int upperBound, int amount)
        {
            Random rnd = new Random();
            List<int> nrList = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                nrList.Add(rnd.Next(lowerBound, upperBound + 1));
                Console.WriteLine(nrList[i]);
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
    }
}