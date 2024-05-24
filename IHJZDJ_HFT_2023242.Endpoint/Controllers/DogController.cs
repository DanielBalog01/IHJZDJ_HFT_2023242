using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IHJZDJ_HFT_2023242.Logic;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
