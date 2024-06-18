using System;

namespace Sort_opdracht
{
    internal class KeepListSorted
    {
        private List<int> array;

        public KeepListSorted()
        {
            array = new List<int>();
        }

        public List<int> Sort(List<int> input)
        {
            this.array = new List<int>(input);
            SortFunction(0, array.Count - 1);
            return this.array;
        }

        public void SortFunction(int start, int end)
        {
            for (int i = start + 1; i < end + 1; i++)
            {
                List<int> prevNums = array.GetRange(start, i); // nums before i
                int eval = array[i];
                for (int j = start; j < i; j++)
                {
                    if (eval < array[j])
                    {
                        array.RemoveAt(i);
                        array.Insert(j, eval);

                        break;
                    }
                }
            }
        }
    }
}