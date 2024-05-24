using System.Linq;
using IHJZDJ_HFT_2023242.Models;
using System.Collections.Generic;
using IHJZDJ_HFT_2023242.Repository;

namespace IHJZDJ_HFT_2023242.Logic
{
    public interface IDogLogic
    {
        void Create(Dog item);
        void Delete(int id);
        Dog Read(int id);
        IEnumerable<Dog> ReadAll();
        void Update(Dog item);
        public IEnumerable<Dog> GoldenRetDog();

        public IEnumerable<Dog> JohnDogs();

        public IEnumerable<Dog> Below5YearsAndTheirBreed();

        public IEnumerable<string> DogByBreed(string breed);

        public IEnumerable<string> DogsByOwner(string owner);
    }
}
