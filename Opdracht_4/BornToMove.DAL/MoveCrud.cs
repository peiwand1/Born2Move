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

        public void create(Move move)
        {
            context.Move.Add(move);
            context.SaveChanges();
        }

        public void update(Move move)
        {
            context.Move.Update(move);
            context.SaveChanges();
        }

        public void delete(int id)
        {
            Move? move = readMoveById(id);
            if (move != null)
            {
                context.Move.Remove(move);
                context.SaveChanges();
            }
        }

        public Move readMoveById(int id)
        {
            IQueryable<Move> result = context.Move.Where(m => m.id == id);
            if (result.Count() > 0) return result.First();

            return new Move(1, "404", "Move could not be found", 1);
        }

        public DbSet<Move> readAllMoves()
        {
            return context.Move;
        }
    }
}
