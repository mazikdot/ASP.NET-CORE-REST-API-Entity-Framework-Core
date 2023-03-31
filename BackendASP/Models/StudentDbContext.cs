using Microsoft.EntityFrameworkCore;

namespace BackendASP.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set collation for the database
            modelBuilder.UseCollation("Thai_CI_AS");
        }
        public DbSet<Percel> Percels { get; set; }
        public DbSet<Category> Categorys { get; set; }

      //  public DbSet<TypeCategory> TypeCategorys { get; set; }
      
    }
}
