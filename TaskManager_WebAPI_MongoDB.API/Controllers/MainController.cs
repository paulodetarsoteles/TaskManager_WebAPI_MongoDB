using Microsoft.AspNetCore.Mvc;
using TaskManager_WebAPI_MongoDB.DAL.Models;
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _repository.GetAll();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar entidades - {DateTime.Now} - {ex.Message}");
                return BadRequest("Erro ao buscar entidades");
            }
        }

        // GET apiV1/main/GetByName/teste
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var task = await _repository.GetByName(name);
                return Ok(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar entidade {name} - {DateTime.Now} - {ex.Message}");
                return BadRequest($"Erro ao buscar entidade {name} - {DateTime.Now}");
            }
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
