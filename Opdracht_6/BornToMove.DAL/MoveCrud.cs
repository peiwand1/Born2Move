using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data.SqlClient;

namespace BornToMove.DAL
{
    public class MoveCrud
    {
        MoveContext context;

        public MoveCrud(MoveContext aContext)
        {
            context = aContext;
        }

        public bool create(Move move)
        {
            try
            {
                context.Move.Add(move);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update(Move move)
        {
            try
            {
                context.Move.Update(move);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int id)
        {
            try
            {
                Move? move = readMoveById(id);
                if (move == null) return false;

                context.Move.Remove(move);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Move readMoveById(int id)
        {
            //IQueryable<Move> result = context.Move.Where(m => m.id == id);
            IQueryable<Move> result = from m in context.Move
                                      where m.id == id
                                      select m;

            if (result.Count() > 0) return result.First();

            return new Move(1, "404", "Move could not be found", 1);
        }

        public List<Move> readAllMoves()
        {
            //return context.Move.ToList();
            return (from m in context.Move
                    select m).ToList();
        }
    }
}
