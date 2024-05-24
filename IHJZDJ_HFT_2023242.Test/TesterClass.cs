using NUnit.Framework;
using Moq;
using IHJZDJ_HFT_2023242.Logic;
using IHJZDJ_HFT_2023242.Repository;
using IHJZDJ_HFT_2023242.Models;
using System.Collections.Generic;
using System.Linq;

namespace IHJZDJ_HFT_2023242.Test
{
    [TestFixture]
    public class TesterClass
    {
        DogLogic dl;
        BreedLogic bl;
        OwnerLogic ol;

        Mock<IRepository<Dog>> mockDogRepository;
        Mock<IRepository<Breed>> mockBreedRepository;
        Mock<IRepository<Owner>> mockOwnerRepository;

        [SetUp]
        public void Init()
        {
            var breedList = new List<Breed>
            {
                new Breed { BreedId = 1, BreedName = "Poodle" },
                new Breed { BreedId = 2, BreedName = "Bulldog" },
                new Breed { BreedId = 3, BreedName = "Beagle" },
                new Breed { BreedId = 4, BreedName = "Golden Retriever" }
            };

            var ownerList = new List<Owner>
            {
                new Owner { OwnerId = 1, OwnerName = "Alice Johnson" },
                new Owner { OwnerId = 2, OwnerName = "Bob Brown" },
                new Owner { OwnerId = 3, OwnerName = "Charlie Davis" },
                new Owner { OwnerId = 4, OwnerName = "John Doe" }
            };

            var dogList = new List<Dog>
            {
                new Dog { DogId = 1, DogName = "Rocky", Age = 2, BreedId = 1, OwnerId = 1, Breed = breedList[0], Owner = ownerList[0] },
                new Dog { DogId = 2, DogName = "Milo", Age = 4, BreedId = 2, OwnerId = 2, Breed = breedList[1], Owner = ownerList[1] },
                new Dog { DogId = 3, DogName = "Oscar", Age = 3, BreedId = 3, OwnerId = 3, Breed = breedList[2], Owner = ownerList[2] },
                new Dog { DogId = 4, DogName = "Daisy", Age = 5, BreedId = 1, OwnerId = 2, Breed = breedList[0], Owner = ownerList[1] },
                new Dog { DogId = 5, DogName = "Luna", Age = 1, BreedId = 3, OwnerId = 1, Breed = breedList[2], Owner = ownerList[0] },
                new Dog { DogId = 6, DogName = "Chili", Age = 3, BreedId = 4, OwnerId = 4, Breed = breedList[3], Owner = ownerList[3] },
                new Dog { DogId = 7, DogName = "Max", Age = 4, BreedId = 4, OwnerId = 4, Breed = breedList[3], Owner = ownerList[3] },
                new Dog { DogId = 8, DogName = "Buddy", Age = 1, BreedId = 4, OwnerId = 4, Breed = breedList[3], Owner = ownerList[3] }
            };

            mockDogRepository = new Mock<IRepository<Dog>>();
            mockBreedRepository = new Mock<IRepository<Breed>>();
            mockOwnerRepository = new Mock<IRepository<Owner>>();

            mockDogRepository.Setup(repo => repo.ReadAll()).Returns(dogList.AsQueryable());
            mockBreedRepository.Setup(repo => repo.ReadAll()).Returns(breedList.AsQueryable());
            mockOwnerRepository.Setup(repo => repo.ReadAll()).Returns(ownerList.AsQueryable());

            dl = new DogLogic(mockDogRepository.Object, mockBreedRepository.Object, mockOwnerRepository.Object);
            bl = new BreedLogic(mockBreedRepository.Object);
            ol = new OwnerLogic(mockOwnerRepository.Object);
        }

        [Test]
        public void CreateDogTest()
        {
            // Arrange
            var dog = new Dog() { DogName = "Gyutyuslutyus" };

            // Act
            dl.Create(dog);

            // Assert
            mockDogRepository.Verify(r => r.Create(dog), Times.Once);
        }

        [Test]
        public void CreateBreedTest()
        {
            // Arrange
            var breed = new Breed() { BreedName = "Beagle" };

            // Act
            bl.Create(breed);

            // Assert
            mockBreedRepository.Verify(r => r.Create(breed), Times.Once);
        }

        [Test]
        public void CreateOwnerTest()
        {
            // Arrange
            var owner = new Owner() { OwnerName = "Andy Black" };

            // Act
            ol.Create(owner);

            // Assert
            mockOwnerRepository.Verify(r => r.Create(owner), Times.Once);
        }

        [Test]
        public void DeleteDogTest()
        {
            // Act
            mockDogRepository.Object.Delete(1);

            // Assert
            mockDogRepository.Verify(d => d.Delete(1), Times.Once);
        }

        [Test]
        public void DeleteBreedTest()
        {
            // Act
            mockBreedRepository.Object.Delete(1);

            // Assert
            mockBreedRepository.Verify(d => d.Delete(1), Times.Once);
        }

        [Test]
        public void DogsByBreedTest()
        {
            // Arrange
            var expectedDogNames = mockDogRepository.Object.ReadAll()
                .Where(x => x.Breed.BreedName == "Golden Retriever")
                .Select(x => x.DogName)
                .ToList();

            // Act
            var result = dl.DogByBreed("Golden Retriever").ToList();

            // Assert
            Assert.AreEqual(expectedDogNames, result);
        }

        [Test]
        public void DogsByOwnerTest()
        {
            // Arrange
            var expectedDogNames = mockDogRepository.Object.ReadAll()
                .Where(x => x.Owner.OwnerName == "Alice Johnson")
                .Select(x => x.DogName)
                .ToList();

            // Act
            var result = dl.DogsByOwner("Alice Johnson").ToList();

            // Assert
            Assert.AreEqual(expectedDogNames, result);
        }

        [Test]
        public void Below5YearsnAndTheirBreedTest()
        {
            var result = dl.Below5YearsAndTheirBreed();


            Assert.AreEqual(7, result.Count());
            Assert.IsTrue(result.All( x => x.Age<=5));
        
        }

        [Test]
        public void JohnDogsTest()
        {
            // Act
            var result = dl.JohnDogs().ToList();

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.All(p => p.Owner.OwnerName == "John Doe"));
            Assert.IsTrue(result.All(p => p.OwnerId == 4));
        }

        [Test]
        public void GoldenRetDogsTest()
        {

            var result = dl.GoldenRetDog();

            // Assert
            Assert.AreEqual(3, result.Count());
            Assert.IsTrue(result.All(p => p.Breed.BreedName == "Golden Retriever"));
            Assert.IsTrue(result.All(p => p.BreedId == 4));
        }

        

    }
}
