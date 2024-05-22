using System.Linq;
using IHJZDJ_HFT_2023242.Models;
using System.Collections.Generic;

namespace IHJZDJ_HFT_2023242.Logic.Interfaces
{
    public interface IBreed
    {
        void Create(Breed item);
        void Delete(int id);
        Breed Read(int id);
        IEnumerable<Breed> ReadAll();
        void Update(Breed item);
    }
}
