using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHJZDJ_HFT_2023242.Models;
using IHJZDJ_HFT_2023242.Repository;

namespace IHJZDJ_HFT_2023242.Logic
{
    public class DogLogic : IDogLogic
    {
        IRepository<Dog> repository;
        IRepository<Breed> breedrepository;
        IRepository<Owner> ownerrepository;


        public DogLogic(IRepository<Dog> repository, IRepository<Breed> breedrepository, IRepository<Owner> ownerrepository)
        {
            this.repository = repository;
            this.breedrepository = breedrepository;
            this.ownerrepository = ownerrepository;
        }

        public void Create(Dog item)
        {
            if (item.DogName is null || item.DogName.Length < 4) throw new ArgumentException("Wrong dog name");
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Dog Read(int id)
        {
            return this.repository.Read(id);
        }

        public IEnumerable<Dog> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Dog item)
        {
            if (item.DogName is null || item.DogName.Length < 4) throw new ArgumentException("Wrong dog name");
            this.repository.Update(item);
        }


        public IEnumerable<Dog> GoldenRetDog()
        {
            var result = from source in repository.ReadAll()
                         from source2 in breedrepository.ReadAll()
                         where source.BreedId == source2.BreedId && source2.BreedName == "Golden Retriever"
                         select new Dog
                         {
                             DogName = source.DogName,
                             Age = source.Age,
                             Breed = source.Breed,
                             BreedId = source.BreedId,
                             Owner = source.Owner,
                             OwnerId = source.OwnerId,
                             DogId = source.DogId
                         };
            return result;

        }

        public IEnumerable<Dog> JohnDogs()
        {
            var res = from source in repository.ReadAll()
                      from s2 in ownerrepository.ReadAll()
                      where source.OwnerId == s2.OwnerId && s2.OwnerName == "John Doe"
                      select new Dog
                      {
                          DogName = source.DogName,
                          Age = source.Age,
                          Owner = source.Owner,
                          OwnerId = source.OwnerId,
                          BreedId = source.BreedId,
                          Breed= source.Breed,
                          DogId = source.DogId
                      };


            return res;
        }


        public IEnumerable<Dog> Below5YearsAndTheirBreed()
        {
            var res = from s in repository.ReadAll()
                      from s2 in ownerrepository.ReadAll()
                      from s3 in breedrepository.ReadAll()
                      where s.BreedId == s3.BreedId && s.OwnerId == s2.OwnerId && s.Age < 5
                      select new Dog
                      {
                          DogName = s.DogName,
                          Age = s.Age,
                          Breed = s.Breed,
                          BreedId = s.BreedId,
                          Owner = s.Owner,
                          OwnerId = s.OwnerId,
                          DogId = s.DogId
                      };
            return res;
        }



        public IEnumerable<string> DogByBreed(string country)
        {
            var res = from s in repository.ReadAll()
                      from s2 in breedrepository.ReadAll()
                      where s.BreedId == s2.BreedId && s2.BreedName.ToLower() == country.ToLower()
                      select s.DogName;
            return res;
        }

        public IEnumerable<string> DogsByOwner(string team)
        {
            var res = from s in repository.ReadAll()
                      from s2 in breedrepository.ReadAll()
                      from s3 in ownerrepository.ReadAll()
                      where s.BreedId == s2.BreedId && s.OwnerId == s3.OwnerId && s2.BreedName.ToLower() == team.ToLower()
                      select s.DogName;

            return res;
        }


    }
}
