using Microsoft.EntityFrameworkCore;

namespace Shopmaster_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //veritabanı tablosu oluşturmak için
        public DbSet<Models.Category> Categories { get; set; }

        //veritabanı tablosu besleme işlemi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Category>().HasData(
                   new Models.Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                   new Models.Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                   new Models.Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }

    }
}
