using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sort_opdracht
{
    internal class RotateSort
    {
        private List<int> array;
        Random rnd;

        public RotateSort()
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

        // recursive function for sorting
        private List<int> Partitioning(List<int> partition)
        {
            // immediately return if list is 1 element or smaller
            // this stops further recursion when it doesn't serve a purpose
            if (partition.Count <= 1) return partition;

            // create 2 lists, 1 for values smaller than pivot, one for values bigger or equal to pivot
            List<int> prePivot = new List<int>();
            List<int> postPivot = new List<int>();
            int pivotVal = rnd.Next(0, partition.Count); // choose a random number as pivot

            // loop over list and put each value in either prePivot or postPivot
            for (int i = 0; i < partition.Count; i++)
            {
                if (i == pivotVal) continue; // don't do anything with pivot itself

                if (partition[i] < partition[pivotVal])
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
            tmp.Add(partition[pivotVal]); // add pivot between pre and post
            tmp.AddRange(Partitioning(postPivot));

            return tmp;
        }
    }
}
