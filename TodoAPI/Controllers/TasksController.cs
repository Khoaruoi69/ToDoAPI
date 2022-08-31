using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Models.ViewModel.Tasks;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepositorycs _TaskRepository;

        public TasksController(ITaskRepositorycs TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                var result = _TaskRepository.GetAll();
                if (result.Count == 0)
                {
                    return NoContent();
                }
                return Ok(_TaskRepository.GetAll());
            }
            catch (Exception ex )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{ids}")]
        public IActionResult GetById(Guid ids)
        {
            try
            {
                var  task = _TaskRepository.GetById(ids);
                if (task != null)
                {
                    return Ok(task);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}/GetUser")]
        public IActionResult GetUser(Guid id)
        {
            try
            {
                var task = _TaskRepository.GetTask(id);
                if (task != null)
                {
                    return Ok(task);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{ids}")]
        public IActionResult Update(UpdateTasks task, Guid ids)
        {

            try
            {
                _TaskRepository.Update(task, ids);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        [HttpDelete("{ids}")]
        public IActionResult Delete(Guid ids)
        {

            try
            {
                _TaskRepository.Delete(ids);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(CreateTask _task)
        {
            try
            {
                return Ok(_TaskRepository.Add(_task));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
    }
}
