namespace Sort_opdracht
{
    public class RotateSort<T> where T : IComparable<T>
    {
        private List<T> array;
        Random rnd;

        public RotateSort()
        {
            array = new List<T>();
            rnd = new Random();
        }
        public List<T> Sort(List<T> input)
        {
            this.array = new List<T>(input);
            SortFunction(0, array.Count);
            return this.array;
        }
        private void SortFunction(int start, int end)
        {
            array = Partitioning(array.GetRange(start, end - start));
        }

        private List<T> Partitioning(List<T> partition)
        {
            // immediately return if list is 1 element or smaller to prevent infinite recursion
            if (partition.Count <= 1) return partition;

            // create 2 lists, 1 for values smaller than pivot, one for values bigger or equal to pivot
            List<T> prePivot = new List<T>();
            List<T> postPivot = new List<T>();
            int pivotIndex = rnd.Next(0, partition.Count); // choose a random number as pivot

            // loop over list and put each value in either prePivot or postPivot
            for (int i = 0; i < partition.Count; i++)
            {
                if (i == pivotIndex) continue; // don't do anything with pivot itself

                if (partition[i].CompareTo(partition[pivotIndex]) == -1)
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
            List<T> tmp = new List<T>(Partitioning(prePivot));
            tmp.Add(partition[pivotIndex]); // add pivot between pre and post
            tmp.AddRange(Partitioning(postPivot));

            return tmp;
        }
    }
}
