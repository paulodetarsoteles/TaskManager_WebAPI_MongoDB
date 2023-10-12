using Microsoft.AspNetCore.Mvc;
using TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces;

namespace TaskManager_WebAPI_MongoDB.API.Controllers
{
    [Route("apiV1/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public MainController(ITaskRepository repository) => _repository = repository;

        // GET: api/<MainController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MainController>/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return "value";
        }

        // POST api/<MainController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MainController>/5
        [HttpPut("{name}")]
        public void Put(string name, [FromBody] string value)
        {
        }

        // DELETE api/<MainController>/5
        [HttpDelete("{id}")]
        public void Delete(string name)
        {
        }
    }
}
