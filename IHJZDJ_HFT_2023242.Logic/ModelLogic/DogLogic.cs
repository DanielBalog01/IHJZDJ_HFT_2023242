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
            if (item.DogName is null || item.DogName.Length < 4) throw new ArgumentException("Wrong player name");
            this.repository.Update(item);
        }


        public IEnumerable<Dog> GoldenRetDog()
        {
            var result = from source in repository.ReadAll()
                         from source2 in breedrepository.ReadAll()
                         where source.BreedId == source2.BreedId && source2.BreedName == "Golden Retriver"
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



    }
}
