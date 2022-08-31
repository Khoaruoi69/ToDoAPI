using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Models.ViewModel.Tasks;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Services
{
    public class TaskRepository : ITaskRepositorycs
    {
        private MyDbContext _context;

        public TaskRepository(MyDbContext context)
        {
            _context = context;
        }

        public CreateTask Add(CreateTask task)
        {
            var _task = new Datas.Task
            {

                name = task.Name,
                description = task.Description,
                isComplete = task.IsComplete,
                Id = task.Id,
            };
            _context.Add(_task);
            _context.SaveChanges();

            return new CreateTask
            {
                Name = _task.name,
                Description = _task.description,
                IsComplete = _task.isComplete,
                Id = _task.Id
            };

        }

        public void Delete(Guid ids)
        {
            var task = _context.TaskDB.FirstOrDefault(u => u.Ids == ids);
            if (task != null)
            {
                _context.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<Tasks> GetAll()
        {
            var tasks = _context.TaskDB.Select(u => new Models.Tasks
            {
                Ids = u.Ids,
                Name = u.name,
                Description = u.description,
                IsComplete = u.isComplete,
                Id = u.Id
            });
            return tasks.ToList();
        }

        public TasksVM GetById(Guid ids)
        {
            var task = _context.TaskDB.FirstOrDefault(u => u.Ids == ids);
            if (task != null)
            {
                return new TasksVM
                {
                    Ids = task.Ids,
                    Name = task.name,
                    Description = task.description,
                    IsComplete = task.isComplete,
                    Id = task.Id
                };
            }
            return null;
        }

        public List<GetTask> GetTask(Guid id)
        {
            var tasksss = _context.TaskDB.Where(u => u.Id == id).Select(u => new GetTask
            {
                Ids = u.Ids,
                Name = u.name,
                Description = u.description,
                IsComplete = u.isComplete,
                Id = u.Id
            });

            return tasksss.ToList();
        }

        public void Update(UpdateTasks task, Guid ids)
        {
            var _task = _context.TaskDB.FirstOrDefault(u => u.Ids == ids);
            if (_task != null)
            {
                _task.name = task.Name;
                _task.description = task.Description;
                _task.isComplete = task.IsComplete;
                _task.Id = task.Id;
                _context.SaveChanges();
            }
        }





        //public Models.ViewModel.TasksVM Add(Models.Tasks task)
        //{
        //    var _task= new Datas.Task
        //    {

        //        name = task.name,
        //        description = task.description,
        //        isComplete = task.isComplete,
        //        Id = task.Id
        //    };
        //    _context.Add(_task);
        //    _context.SaveChanges();
        //    return new Models.Tasks
        //    {

        //        name = _task.name,
        //        description = _task.description,
        //        isComplete = _task.isComplete,
        //        Id = _task.Id
        //    };
        //}

        //public void Delete(Guid ids)
        //{
        //    var task = _context.TaskDB.FirstOrDefault(u => u.Ids == ids);
        //    if (task != null)
        //    {
        //        _context.Remove(task);
        //        _context.SaveChanges();
        //    }
        //}

        //public List<Models.TasksVM> GetAll()
        //{
        //    var tasks = _context.TaskDB.Select(u => new Models.Tasks
        //    {
        //        Ids = u.Ids,
        //        name = u.name,
        //        description= u.description,
        //        isComplete= u.isComplete,
        //        Id= u.Id
        //    });
        //    return tasks.ToList();
        //}

        //public Models.Tasks GetById(Guid ids)
        //{
        //    var task = _context.TaskDB.FirstOrDefault(u => u.Ids == ids);
        //    if (task != null)
        //    {
        //        return new Models.TasksVM
        //        {
        //            Ids = task.Ids,
        //            name = task.name,
        //            description = task.description,
        //            isComplete= task.isComplete,
        //            Id= task.Id
        //        };
        //    }
        //    return null;
        //}



        //public void Update(Models.Tasks task, Guid ids)
        //{
        //    var _task = _context.TaskDB.FirstOrDefault(u => u.Ids == ids);
        //    if (_task != null)
        //    {
        //        _task.name = task.name;
        //        _task.description = task.description;
        //        _task.isComplete = task.isComplete;
        //        _task.Id = task.Id;
        //        _context.SaveChanges();
        //    }
        //}

        // public List<Models.Tasks> GetUser(Guid idsss)
        //{
        //    var tasksss = _context.TaskDB.Where(u => u.Id == idsss).Select(u => new Models.Tasks
        //    {
        //        Ids = u.Ids,
        //        name = u.name,
        //        description = u.description,
        //        isComplete = u.isComplete,
        //        Id = u.Id
        //    });

        //    return tasksss.ToList();



        //}
    }
}
