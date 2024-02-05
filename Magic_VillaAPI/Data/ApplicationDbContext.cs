using Magic_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Magic_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
            { 
            }
        
        public DbSet<Villa> Villas  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Villa>().HasData(
               new Villa()
               {
                   Id = 1,
               } 
        }
    }
}
