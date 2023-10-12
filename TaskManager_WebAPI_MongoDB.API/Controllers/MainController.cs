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

        // GET: apiV1/main/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET apiV1/main/GetByName/teste
        [HttpGet("GetByName/{name}")]
        public string GetByName(string name)
        {
            return "value";
        }

        // POST apiV1/main/Create
        [HttpPost("Create")]
        public void Create([FromBody] string value)
        {
        }

        // PUT apiV1/main/Update/teste
        [HttpPut("Update/{name}")]
        public void Update(string name, [FromBody] string value)
        {
        }

        // DELETE apiV1/main/Delete/teste
        [HttpDelete("Delete/{name}")]
        public void Delete(string name)
        {
        }
    }
}
