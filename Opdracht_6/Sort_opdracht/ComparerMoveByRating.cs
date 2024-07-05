using BornToMove.DAL;

namespace Sort_opdracht
{
    public class ComparerMoveByRating : IComparer<Move>
    {
        MoveContext context;

        public ComparerMoveByRating(MoveContext aContext)
        {
            context = aContext;
        }

        public int Compare(Move? x, Move? y)
        {
            if (x == null) return -1;
            if (y == null) return 1;

            double? xAvg;
            double? yAvg;

            try
            {
                xAvg = context.MoveRating.Where(r => r.move.id == x.id).Average(r => r.rating);
            }
            catch
            {
                return -1;
            }

            try
            {
                yAvg = context.MoveRating.Where(r => r.move.id == y.id).Average(r => r.rating);
            }
            catch
            {
                return 1;
            }

            if (xAvg > yAvg) return 1;
            if (xAvg < yAvg) return -1;
            return 0;
        }
    }
}
