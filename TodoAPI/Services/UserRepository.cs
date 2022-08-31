using TodoAPI.Models.ViewModel;
using TodoAPI.Models.ViewModel.Users;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Services
{

    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public CreateUser Add(CreateUser user)
        {
            var _user = new Datas.User
            {
                Name = user.Name,
                password = user.Password
            };
            _context.Add(_user);
            _context.SaveChanges();
            return new CreateUser
            {   
                Name = _user.Name,
                Password = _user.password
            };
        }

        public void Delete(Guid id)
        {
            var user = _context.UserDB.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<UsersVM> GetAll()
        {
            var users = _context.UserDB.Select(u => new UsersVM
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.password
            });
            return users.ToList();
        }

        public UsersVM GetById(Guid id)
        {
            var user = _context.UserDB.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return new UsersVM
                {
                    Id = user.Id,
                    Name = user.Name,
                    Password = user.password
                };

            }
            return null;
        }

        public LoginUser Login(string name, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateUser user, Guid id)
        {
            var _user = _context.UserDB.FirstOrDefault(u => u.Id == id);
            if (_user != null)
            {
                _user.Name = user.Name;
                _user.password = user.Password;
                _context.SaveChanges();
            }
        }



        //public Users Add(Users user)
        //{

        //    var _user = new User
        //    {
        //        Name = user.Name,
        //        password = user.password
        //    };
        //    _context.Add(_user);
        //    _context.SaveChanges();
        //    return new Users
        //    {
        //        Id= _user.Id,
        //        Name= _user.Name,
        //        password=_user.password
        //    };
        //}



        //public List<Users> GetAll()
        //{
        //    var users = _context.UserDB.Select(u => new Users
        //    {
        //        Id=u.Id,
        //        Name=u.Name,
        //        password=u.password
        //    });
        //    return users.ToList();
        //}

        //public Users GetById(Guid id)
        //{
        //    var user = _context.UserDB.FirstOrDefault(u => u.Id == id);
        //    if (user != null)
        //    {
        //        return new Users
        //        {
        //            Id = user.Id,
        //            Name=user.Name,
        //            password=user.password
        //        };
        //    }
        //    return null;
        //}

        //public Users Login(string name, string password)
        //{
        //    var user = _context.UserDB.FirstOrDefault(u => u.Name == name &&u.password==password);
        //    if (user != null)
        //    {
        //        return new Users
        //        {
        //            Id = user.Id,
        //            Name = user.Name,
        //            password = user.password
        //        };
        //    }
        //    return null;
        //}

        //public void Update(Users user, Guid id)
        //{
        //    var _user = _context.UserDB.FirstOrDefault(u => u.Id == id);
        //    if (_user != null)
        //    {
        //        _user.Name= user.Name;
        //        _user.password = user.password;
        //        _context.SaveChanges();
        //    }
        //}

        //public void Delete(Guid id)
        //{
        //    var user = _context.UserDB.FirstOrDefault(u => u.Id == id);
        //    if (user != null)
        //    {
        //        _context.Remove(user);
        //        _context.SaveChanges();
        //    }
        //}
    }
}
