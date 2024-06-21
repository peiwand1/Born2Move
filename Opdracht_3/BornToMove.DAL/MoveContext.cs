using Microsoft.EntityFrameworkCore;
using BornToMove;

namespace BornToMove.DAL
{
    public class MoveContext : DbContext
    {
        public DbSet<Move> Move { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=(localdb)\\ProjectModels;database=born2move;Trusted_Connection=true;TrustServerCertificate=true;");
            base.OnConfiguring(builder);
        }


    }
}
