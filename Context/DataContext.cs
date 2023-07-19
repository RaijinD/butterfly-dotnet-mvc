using Microsoft.EntityFrameworkCore;
using butterfly_dotnet_mvc.Models;

namespace butterfly_dotnet_mvc.Context
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Post>(entity =>
            {
                entity.HasOne(p => p.Owner)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(up => up.OwnerId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
