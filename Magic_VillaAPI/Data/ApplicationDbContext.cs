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
        
        public DbSet<House> Houses  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().HasData(
                new House()
                {
                    Id = 1,
                    Name = "Pool View",
                    Sqft = 3000,
                    Address = "Aduragbemi",
                    HouseNumber = 1,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                },
                new House()
                {
                    Id = 2,
                    Name = "Beach View",
                    Sqft = 3200,
                    Address = "Yenusi",
                    HouseNumber = 2,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                },
                new House()
                {
                    Id = 3,
                    Name = "Liverpool View",
                    Sqft = 3500,
                    Address = "Aderibigbe",
                    HouseNumber = 3,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                },
                new House()
                {
                    Id = 4,
                    Name = "Las-Vegas View",
                    Sqft = 3800,
                    Address = "Crescent",
                    HouseNumber = 4,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                },
                new House()
                {
                    Id = 5,
                    Name = "Alaska View",
                    Sqft = 4000,
                    Address = "Aduragbemi",
                    HouseNumber = 5,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                },
                new House()
                {
                    Id = 6,
                    Name = "Manchester View",
                    Sqft = 4500,
                    Address = "Aduragbemi",
                    HouseNumber = 6,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                },
                new House()
                {
                    Id = 7,
                    Name = "Lagoon View",
                    Sqft = 4600,
                    Address = "Aduragbemi",
                    HouseNumber = 7,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                }
                ); 
        }
    }
}
