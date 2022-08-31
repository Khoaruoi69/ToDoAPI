using TodoAPI.Models;
using TodoAPI.Models.ViewModel.Tasks;

namespace TodoAPI.Services.Interfaces
{
    public interface ITaskRepositorycs
    {
        List<Tasks> GetAll();
        TasksVM GetById(Guid ids);
        List<GetTask> GetTask(Guid id);
        CreateTask Add(CreateTask task);
        void Update(UpdateTasks task, Guid ids);
        void Delete(Guid ids);
    }
}
