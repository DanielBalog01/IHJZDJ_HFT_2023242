using System.Linq;
using IHJZDJ_HFT_2023242.Models;
using System.Collections.Generic;

namespace IHJZDJ_HFT_2023242.Logic
{
    public interface IDogLogic
    {
        void Create(Dog item);
        void Delete(int id);
        Dog Read(int id);
        IEnumerable<Dog> ReadAll();
        void Update(Dog item);
    }
}
