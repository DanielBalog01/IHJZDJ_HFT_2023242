using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHJZDJ_HFT_2023242.Models;
using IHJZDJ_HFT_2023242.Repository;

namespace IHJZDJ_HFT_2023242.Logic
{
    public class BreedLogic : IBreedLogic
    {
        IRepository<Breed> repository;

        public BreedLogic(IRepository<Breed> repository) 
        {
            this.repository = repository;
        }
        public void Create(Breed item)
        {
            if (item.BreedName is null || item.BreedName.Length < 2) throw new ArgumentException("Wrong breed name!");
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Breed Read(int id)
        {
            return this.repository.Read(id);
        }

        public IEnumerable<Breed> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Breed item)
        {
            if (item.BreedName is null || item.BreedName.Length < 2) throw new ArgumentException("Wrong breed name!");
            this.repository.Update(item);
        }
    }
}
