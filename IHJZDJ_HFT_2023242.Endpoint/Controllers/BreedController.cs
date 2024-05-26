using IHJZDJ_HFT_2023242.Logic;
using IHJZDJ_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IHJZDJ_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        IBreedLogic logic;

        public BreedController(IBreedLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Breed> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Breed Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Breed value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update(int id, [FromBody] Breed value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
