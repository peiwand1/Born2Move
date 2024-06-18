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

        private List<int> Partitioning(List<int> partition)
        {
            if (partition.Count <= 1) return partition; // do nothing if list is 1 element or smaller

            List<int> prePivot = new List<int>();
            List<int> postPivot = new List<int>();
            int pivotVal = rnd.Next(0, partition.Count);

            for (int i = 0; i < partition.Count; i++)
            {
                if (i == pivotVal) continue; // don't compare pivot to self

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
            List<int> tmp = new List<int>(Partitioning(prePivot));
            tmp.Add(partition[pivotVal]); // add pivot between pre and post
            tmp.AddRange(Partitioning(postPivot));

            return tmp;
        }
    }
}
