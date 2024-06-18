using System;
using System.Collections.Generic;
namespace Sort_opdracht
{
    internal class ShiftHighestSort
    {
        private List<int> array;

        public ShiftHighestSort()
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
                for (int j = start; j < end - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        //Console.WriteLine(array[j] + " > " + array[j+1] + " swapped");
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                    else
                    {
                        //Console.WriteLine(array[j] + " < " + array[j + 1] + " not swapped");

                    }
                }
            }
        }
    }
}
