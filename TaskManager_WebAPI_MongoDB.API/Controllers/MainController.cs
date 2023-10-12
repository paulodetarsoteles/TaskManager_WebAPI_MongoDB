using Microsoft.AspNetCore.Mvc;
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

                if (tasks is null || !tasks.Any())
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
        public IActionResult GetByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return NotFound("Nome inválido. ");

                var task = _repository.GetByName(name);

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
        public IActionResult Update(string name, [FromBody] TaskToDoDTO taskInput)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return NoContent();

                TaskToDo? oldTask = _repository.GetByName(name);

                if (oldTask is null)
                    return StatusCode(StatusCodes.Status204NoContent, $"Nenhuma entidade com o nome {name} foi encontrada.");

                TaskToDo newTask = new(taskInput.Name, taskInput.Value);

                if (taskInput.Done == true)
                    newTask.Done = true;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                newTask.CreationDate = oldTask.CreationDate;
                newTask.UpdateDate = DateTime.Now;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                _repository.Update(name, newTask);

                return Accepted(newTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir entidade {taskInput.Name} - {DateTime.Now} - {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao inserir entidade {taskInput.Name} - {DateTime.Now}.");
            }
        }

        // DELETE apiV1/main/Delete/teste
        [HttpDelete("Delete/{name}")]
        public IActionResult Delete(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return NoContent();

                if (_repository.GetByName(name) is null)
                    StatusCode(StatusCodes.Status204NoContent, $"Nenhuma entidade com o nome {name} foi encontrada.");

                _repository.Delete(name);

                return Ok($"Entidade {name} excluída com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir entidade {name} - {DateTime.Now} - {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao inserir entidade {name} - {DateTime.Now}.");
            }
        }
    }
}
