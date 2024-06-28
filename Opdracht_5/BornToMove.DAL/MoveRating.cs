using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveRating : IComparable<MoveRating>
    {
        public int id { get; set; }
        public Move move { get; set; }
        public double rating { get; set; }
        public double intensity { get; set; }

        public int CompareTo(MoveRating? other)
        {
            if (other == null) return 1;

            if (this.rating > other.rating) return 1;
            if (this.rating < other.rating) return -1;
            return 0;
        }
    }
}
