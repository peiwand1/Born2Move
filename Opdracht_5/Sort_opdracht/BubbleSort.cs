namespace Sort_opdracht
{
    internal class BubbleSort
    {
        private List<int> array;

        public BubbleSort()
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
            for (int i = 0; i < end ; i++)
            {
                // loop over list
                for (int j = start; j < end - i; j++)
                {
                    // if value is bigger than next value, swap them
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
