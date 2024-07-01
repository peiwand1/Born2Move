using BornToMove.DAL;

namespace Sort_opdracht
{
    public class MoveComparer : IComparer<Move>
    {
        MoveContext context;

        public MoveComparer(MoveContext aContext)
        {
            context = aContext;
        }

        public int Compare(Move? x, Move? y)
        {
            if (x == null) return -1;
            if (y == null) return 1;

            double? xAvg = context.MoveRating.Where(r => r.move.id == x.id)
                                             .Average(r => r.rating);
            double? yAvg = context.MoveRating.Where(r => r.move.id == y.id)
                                             .Average(r => r.rating);
            if (xAvg == null && yAvg == null) return 0;
            if (xAvg == null) return -1;
            if (yAvg == null) return 1;

            if (xAvg > yAvg) return 1;
            if (xAvg < yAvg) return -1;
            return 0;
        }
    }
}
