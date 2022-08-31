using System.Reflection.Metadata.Ecma335;
using TodoAPI.Models.ViewModel.Users;

namespace TodoAPI.Services
{
    public class InterfaceUser
    {
        public UsersVM Face_User(UsersVM user)
        {
            return new UsersVM
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };
        }



    }
}
