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
        public double? readAvgMoveIntensityValueByMoveId(int id)
        {
            try
            {
                return context.MoveRating.Where(r => r.move.id == id)
                                         .Average(r => r.intensity);
            }
            catch
            {
                return null;
            }
        }

        public List<MoveRating> readAllMoveAvgRatings()
        {
            List<Move> moves = (from m in context.Move
                                select m).ToList();
            List<MoveRating> avgRatings = new List<MoveRating>();

            foreach (Move move in moves)
            {
                double? avg = readAvgMoveRatingValueByMoveId(move.id);
                double? inten = readAvgMoveIntensityValueByMoveId(move.id);

                MoveRating mr = new MoveRating();
                mr.id = 0;
                mr.move = move;
                mr.rating = (avg != null) ? (double)avg : 0.0;
                mr.intensity = (inten != null) ? (double)inten : 0.0;

                avgRatings.Add(mr);
            }

            return avgRatings;
        }

        public MoveRating readAvgMoveRatingByMoveId(int id)
        {
            double? avg = readAvgMoveRatingValueByMoveId(id);
            double? inten = readAvgMoveIntensityValueByMoveId(id);

            MoveRating mr = new MoveRating();
            mr.id = id;
            mr.move = (from m in context.Move
                       where m.id == id
                       select m).ToList().First();
            mr.rating = (avg != null) ? (double)avg : 0.0;
            mr.intensity = (inten != null) ? (double)inten : 0.0;

            return mr;

        }
    }
}
