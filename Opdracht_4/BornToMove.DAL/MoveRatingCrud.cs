using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data.SqlClient;

namespace BornToMove.DAL
{
    public class MoveRatingCrud
    {
        MoveContext context;

        public MoveRatingCrud(MoveContext aContext)
        {
            context = aContext;
        }

        public void create(MoveRating rating)
        {
            context.MoveRating.Add(rating);
            context.SaveChanges();
        }

        public void update(MoveRating rating)
        {
            context.MoveRating.Update(rating);
            context.SaveChanges();
        }

        public void delete(MoveRating rating)
        {
            context.MoveRating.Remove(rating);
            context.SaveChanges();
        }

        public double readAvgMoveRatingByMoveId(int id)
        {
            return context.MoveRating.Where(r => r.move.id == id)
                .Average(r => r.rating);
        }

        public MoveRating readMoveRating(int id)
        {
            return context.MoveRating.Where(r => r.move.id == id).First();
        }
    }
}
