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

        public double? readAvgMoveRatingValueByMoveId(int id)
        {
            try
            {
                return context.MoveRating.Where(r => r.move.id == id)
                                         .Average(r => r.rating);
            }
            catch
            {
                return null;
            }
        }

        //public MoveRating readMoveRating(int id)
        //{
        //    return context.MoveRating.Where(r => r.move.id == id).First();
        //}

        public List<MoveRating> readAllMoveAvgRatings()
        {
            List<Move> moves = (from m in context.Move
                                select m).ToList();
            List<MoveRating> avgRatings = new List<MoveRating>();

            foreach (Move move in moves)
            {
                double? avg = readAvgMoveRatingValueByMoveId(move.id);

                MoveRating mr = new MoveRating();
                mr.id = 0;
                mr.move = move;
                mr.rating = (avg != null) ? (double)avg : 0.0;
                mr.intensity = 1;

                avgRatings.Add(mr);
            }

            return avgRatings;
        }

        public MoveRating readAvgMoveRatingByMoveId(int id)
        {
            double? avg = readAvgMoveRatingValueByMoveId(id);

            MoveRating mr = new MoveRating();
            mr.id = id;
            mr.move = (from m in context.Move
                       where m.id == id
                       select m).ToList().First();
            mr.rating = (avg != null) ? (double)avg : 0.0;
            mr.intensity = 1;

            return mr;

        }
    }
}
