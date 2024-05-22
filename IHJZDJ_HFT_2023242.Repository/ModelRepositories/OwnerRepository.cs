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
        public override Owner Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Owner item)
        {
            throw new NotImplementedException();
        }
    }
}
