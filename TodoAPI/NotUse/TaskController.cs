using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Datas;

namespace TodoAPI.NotUse
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TaskController(MyDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var TaskList = _context.TaskDB.ToList();
            return Ok(TaskList);
        }

        [HttpGet("{ids}")]
        public IActionResult GetById(string ids)
        {
            var TaskList = _context.TaskDB.SingleOrDefault(ta => ta.Ids == Guid.Parse(ids));
            if (TaskList == null)
            {
                return NotFound();
            }

            return Ok(TaskList);
        }

        [HttpPost]
        public IActionResult Create(TaskModel model)
        {
            try
            {
                var task = new Datas.Task
                {

                    Id = model.Id,
                    name = model.name,
                    description = model.description,
                    isComplete = model.isComplete

                };
                _context.Add(task);
                _context.SaveChanges();
                return Ok(task);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{ids}")]
        public IActionResult UpdateByName(string ids, TaskModel taskedit)
        {
            try
            {
                var TaskList = _context.TaskDB.SingleOrDefault(ta => ta.Ids == Guid.Parse(ids));
                if (TaskList == null)
                {
                    return NotFound();
                }
                if (ids != TaskList.Ids.ToString())
                {
                    return BadRequest();
                }
                // Update

                TaskList.name = taskedit.name;
                TaskList.description = taskedit.description;
                TaskList.isComplete = taskedit.isComplete;
                TaskList.Id = taskedit.Id;

                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }


        [HttpDelete("{ids}")]
        public IActionResult Delete(string ids)
        {
            try
            {
                var TaskList = _context.TaskDB.SingleOrDefault(ta => ta.Ids == Guid.Parse(ids));
                if (TaskList == null)
                {
                    return NotFound();
                }
                if (ids != TaskList.Ids.ToString())
                {
                    return BadRequest();
                }
                _context.Remove(TaskList);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
