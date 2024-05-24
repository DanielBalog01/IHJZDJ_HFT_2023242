using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IHJZDJ_HFT_2023242.Logic;
using IHJZDJ_HFT_2023242.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IHJZDJ_HFT_2023242.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        IDogLogic logic;

        public DogController(IDogLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<DogController>
        [HttpGet]
        public IEnumerable<Dog> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public Dog Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<DogController>
        [HttpPost]
        public void Create([FromBody] Dog value)
        {
            this.logic.Create(value);
        }

        // PUT api/<DogController>/5
        [HttpPut]
        public void Update(int id, [FromBody] Dog value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
