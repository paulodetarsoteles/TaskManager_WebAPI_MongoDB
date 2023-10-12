using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;
using TaskManager_WebAPI_MongoDB.API.DTO;
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

                if (tasks is null)
                    return NoContent();

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar entidades - {DateTime.Now} - {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar entidades.");
            }
        }

        // GET apiV1/main/GetByName/teste
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return NotFound("Nome inválido. ");

                var task = await _repository.GetByName(name);

                if (task is null)
                    return StatusCode(StatusCodes.Status204NoContent, $"Nenhuma entidade com o nome {name} foi encontrada.");

                return Ok(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar entidade {name} - {DateTime.Now} - {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao buscar entidade {name} - {DateTime.Now}.");
            }
        }

        // POST apiV1/main/Create
        [HttpPost("Create")]
        public IActionResult Create([FromBody] TaskToDoDTO taskInput)
        {
            try
            {
                if (taskInput is null)
                    return NoContent();

                if (_repository.GetByName(taskInput.Name) is not null)
                    return BadRequest($"Entidade com o nome {taskInput.Name} já consta na base.");

                TaskToDo newTask = new(taskInput.Name, taskInput.Value);

                if (taskInput.Done == true)
                    newTask.Done = true;

                newTask.CreationDate = DateTime.Now;

                _repository.Insert(newTask);

                return Created("", newTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir entidade {taskInput.Name} - {DateTime.Now} - {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao inserir entidade {taskInput.Name} - {DateTime.Now}.");
            }
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
