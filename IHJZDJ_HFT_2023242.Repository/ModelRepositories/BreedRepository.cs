using IHJZDJ_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHJZDJ_HFT_2023242.Repository
{
    public class BreedRepository : Repository<Breed>, IRepository<Breed>
    {
        public BreedRepository(DogDbContext DbCtx) : base(DbCtx)
        {
            
        }

        public override Breed Read(int id)
        {
            return DbCtx.Breeds.FirstOrDefault(t => t.BreedId == id);
        }

        public override void Update(Breed item)
        {
            var old = Read(item.BreedId);

            if (old != null)
            {
                old.BreedName = item.BreedName;
                DbCtx.SaveChanges();
            }
        }
    }
}
