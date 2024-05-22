using Microsoft.EntityFrameworkCore;
using IHJZDJ_HFT_2023242.Models;


namespace IHJZDJ_HFT_2023242.Repository.Database
{
    public class DogDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
