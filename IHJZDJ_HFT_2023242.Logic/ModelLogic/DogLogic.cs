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
        public void Create(Dog item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Breed Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Dog item)
        {
            throw new NotImplementedException();
        }
    }
}
