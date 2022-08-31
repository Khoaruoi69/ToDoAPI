using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Models.ViewModel.Users;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Test.MockData;

public class MockDataUser:IUserRepository
{
    private readonly List<UsersVM> _usersVMs;
    private readonly MyDbContext _myDbContext;
    public MockDataUser()
    {
        _usersVMs = new List<UsersVM>()
        {
            new UsersVM(){ Id= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),Name="Anh Khoa 1",Password="1234" },
            new UsersVM(){ Id= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201"),Name="Anh 3",Password="1234" },
            new UsersVM(){ Id= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202"),Name="Anh Khoa 132",Password="1234" },
        };
    }

    public CreateUser Add(CreateUser user)
    {
        var _user = new CreateUser()
        {
            Name="khoa",
            Password="234567"
        };
        
        _myDbContext.Add(_user);
        return user;
    }

    public void Delete(Guid id)
    {
       var existing = _usersVMs.FirstOrDefault(x => x.Id == id);
        _usersVMs.Remove(existing);
    }

    public List<UsersVM> GetAll()
    {
        return _usersVMs;
    }

    public UsersVM GetById(Guid id)
    {
        return _usersVMs.Where(a => a.Id == id).FirstOrDefault();  
    }

    public LoginUser Login(string name, string password)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateUser user, Guid id)
    {
        throw new NotImplementedException();
    }
}
