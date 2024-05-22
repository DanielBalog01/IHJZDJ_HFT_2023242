using IHJZDJ_HFT_2023242.Models;
using IHJZDJ_HFT_2023242.Repository.Database;
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
            throw new NotImplementedException();
        }

        public override void Update(Dog item)
        {
            throw new NotImplementedException();
        }
    }
}
