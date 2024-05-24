using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IHJZDJ_HFT_2023242.Logic;
using IHJZDJ_HFT_2023242.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IHJZDJ_HFT_2023242.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {

        IDogLogic logic;

        public StatController(IDogLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Dog> JohnDogs()
        {
            return this.logic.JohnDogs();
        }

        [HttpGet]
        public IEnumerable<Dog> GoldDogs()
        {
            return this.logic.JohnDogs();
        }

        [HttpGet]
        public IEnumerable<Dog> JohnDogs()
        {
            return this.logic.JohnDogs();
        }

        [HttpGet]
        public IEnumerable<Dog> JohnDogs()
        {
            return this.logic.JohnDogs();
        }

        [HttpGet]
        public IEnumerable<Dog> JohnDogs()
        {
            return this.logic.JohnDogs();
        }




    }
}
