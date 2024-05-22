using Microsoft.EntityFrameworkCore;
using IHJZDJ_HFT_2023242.Models;


namespace IHJZDJ_HFT_2023242.Repository
{
    public class DogDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Breed> Breeds { get; set; }


        public DogDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase("DogDb")
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .HasOne(x => x.Breed)
                .WithMany(x => x.Dogs)
                .HasForeignKey(x => x.BreedId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Dog>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Dogs)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

           modelBuilder.Entity<Dog>().HasData(new Dog[]
           {
                new Dog { DogId = 1, DogName = "Buddy", Age = 3, BreedId = 1, OwnerId = 1 },
                new Dog { DogId = 2, DogName = "Charlie", Age = 5, BreedId = 2, OwnerId = 2 },
                new Dog { DogId = 3, DogName = "Max", Age = 2, BreedId = 3, OwnerId = 3 },
                new Dog { DogId = 4, DogName = "Bella", Age = 4, BreedId = 1, OwnerId = 2 },
                new Dog { DogId = 5, DogName = "Lucy", Age = 1, BreedId = 3, OwnerId = 1 }

           });
           modelBuilder.Entity<Owner>().HasData(new Owner[]
           {
                new Owner { OwnerId = 1, OwnerName = "John Doe" },
                new Owner { OwnerId = 2, OwnerName = "Jane Smith" },
                new Owner { OwnerId = 3, OwnerName = "Mike Johnson" }

           });
           modelBuilder.Entity<Breed>().HasData(new Breed[]
           {
                new Breed { BreedId = 1, BreedName = "Labrador Retriever" },
                new Breed { BreedId = 2, BreedName = "German Shepherd" },
                new Breed { BreedId = 3, BreedName = "Golden Retriever" }
           });







        }


    }
}
