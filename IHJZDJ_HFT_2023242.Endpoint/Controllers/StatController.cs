using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IHJZDJ_HFT_2023242.Logic;
using IHJZDJ_HFT_2023242.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IHJZDJ_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {

        IDogLogic logic;


        public StatController(IDogLogic logic)
        {
            this.logic = logic;
        }
        /*
        [HttpGet]
        public IEnumerable<Dog> JohnDogs()
        {
            return logic.JohnDogs();
        }

        [HttpGet]
        public IEnumerable<Dog> GoldenRetDog()
        {
            return logic.GoldenRetDog();
        }

        [HttpGet]
        public IEnumerable<Dog> Below5YearsAndTheirBreed()
        {
            return logic.Below5YearsAndTheirBreed();
        }

        [HttpGet("{breed}")]
        public IEnumerable<string> DogByBreed(string breed)
        {
            return logic.DogByBreed(breed);
        }

        [HttpGet("{owner}")]
        public IEnumerable<string> DogsByOwner(string owner)
        {
            return logic.DogsByOwner(owner);
        }


        */

        [HttpGet]
        public IEnumerable<Dog> JohnDogs()
        {
            return logic.JohnDogs();
        }

        [HttpGet]
        public IEnumerable<Dog> GoldenRetDog()
        {
            return logic.GoldenRetDog();
        }

        [HttpGet]
        public IEnumerable<Dog> Below5YearsAndTheirBreed()
        {
            return logic.Below5YearsAndTheirBreed();
        }

        [HttpGet("{breed}")]
        public IEnumerable<string> DogByBreed(string breed)
        {
            return logic.DogByBreed(breed);
        }

        [HttpGet("{owner}")]
        public IEnumerable<string> DogsByOwner(string owner)
        {
            return logic.DogsByOwner(owner);
        }

    }
}
