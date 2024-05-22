using IHJZDJ_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHJZDJ_HFT_2023242.Repository
{
    public class DogRepository : Repository<Dog>, IRepository<Dog>
    {
        public DogRepository(DogDbContext DbCtx) : base(DbCtx)
        {
        }

        public override Dog Read(int id)
        {
            return DbCtx.Dogs.FirstOrDefault(t => t.DogId == id);
        }

        public override void Update(Dog item)
        {
            var old = Read(item.DogId);
            if (old != null)
            {
                old.DogName = item.DogName;
                old.Age = item.Age;
                old.BreedId = item.BreedId;
                old.OwnerId = item.OwnerId;

                DbCtx.SaveChanges();
            }
        }
    }
}
