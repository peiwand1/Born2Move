namespace Sort_opdracht
{
    internal class InsertionSort
    {
        private List<int> array;

        public InsertionSort()
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
            // loop starting from the second value in list
            for (int i = start + 1; i < end + 1; i++)
            {
                List<int> prevNums = array.GetRange(start, i); // nums before i
                int eval = array[i]; // value to compare with
                for (int j = start; j < i; j++)
                {
                    // whenever a number is bigger than eval, move eval in front of it
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