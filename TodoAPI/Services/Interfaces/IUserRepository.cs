using TodoAPI.Models;
using TodoAPI.Models.ViewModel;
using TodoAPI.Models.ViewModel.Users;

namespace TodoAPI.Services.Interfaces
{
    public interface IUserRepository 
    {
        List<UsersVM> GetAll();
        UsersVM GetById(Guid id);
        CreateUser Add(CreateUser user);
        LoginUser Login(string name, string password);
        void Update(UpdateUser user, Guid id);
        void Delete(Guid id);
    }
}
