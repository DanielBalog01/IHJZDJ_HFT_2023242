using IHJZDJ_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHJZDJ_HFT_2023242.Repository
{
    public class OwnerRepository : Repository<Owner>, IRepository<Owner>
    {
        public OwnerRepository(DogDbContext DbCtx) : base(DbCtx)
        {
        }

        public override Owner Read(int id)
        {
            return DbCtx.Owners.FirstOrDefault(t => t.OwnerId == id);
        }

        public override void Update(Owner item)
        {
            var old = Read(item.OwnerId);
            if (old != null)
            {
                old.OwnerName = item.OwnerName;
                DbCtx.SaveChanges();
            }
        }
    }
}
