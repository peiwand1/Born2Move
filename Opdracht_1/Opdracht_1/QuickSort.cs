﻿namespace Sort_opdracht
{
    internal class QuickSort
    {
        private List<int> array;
        Random rnd;

        public QuickSort()
        {
            array = new List<int>();
            rnd = new Random();
        }
        public List<int> Sort(List<int> input)
        {
            this.array = new List<int>(input);
            SortFunction(0, array.Count);
            return this.array;
        }
        public void SortFunction(int start, int end)
        {
            array = Partitioning(array.GetRange(start, end - start));
        }

        private List<int> Partitioning(List<int> partition)
        {
            // immediately return if list is 1 element or smaller to prevent infinite recursion
            if (partition.Count <= 1) return partition;

            // create 2 lists, 1 for values smaller than pivot, one for values bigger or equal to pivot
            List<int> prePivot = new List<int>();
            List<int> postPivot = new List<int>();
            int pivotIndex = rnd.Next(0, partition.Count); // choose a random number as pivot

            // loop over list and put each value in either prePivot or postPivot
            for (int i = 0; i < partition.Count; i++)
            {
                if (i == pivotIndex) continue; // don't do anything with pivot itself

                if (partition[i] < partition[pivotIndex])
                {
                    // move left
                    prePivot.Add(partition[i]);
                }
                else
                {
                    // move right
                    postPivot.Add(partition[i]);
                }
            }

            // create a new list where values smaller than pivot are to the left
            // and values bigger are to the right
            // recursively call this function on both prePivot and postPivot so they get fully sorted
            List<int> tmp = new List<int>(Partitioning(prePivot));
            tmp.Add(partition[pivotIndex]); // add pivot between pre and post
            tmp.AddRange(Partitioning(postPivot));

            return tmp;
        }
    }
}
