using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHJZDJ_HFT_2023242.Models;
using IHJZDJ_HFT_2023242.Repository;
namespace IHJZDJ_HFT_2023242.Logic
{
    public class OwnerLogic : IOwnerLogic
    {
        IRepository<Owner> repository;

        public OwnerLogic(IRepository<Owner> repository)
        {
            this.repository = repository;
        }
        public void Create(Owner item)
        {
            if (item.OwnerName is null || item.OwnerName.Length < 2) throw new ArgumentException("Wrong owner name!");
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Owner Read(int id)
        {
            return this.repository.Read(id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Owner item)
        {
            if (item.OwnerName is null || item.OwnerName.Length < 2) throw new ArgumentException("Wrong owner name!");
            this.repository.Update(item);
        }
    }
}
