using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Datas;

namespace TodoAPI.NotUse
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly MyDbContext _context;
        public UserController(MyDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var dsUser = _context.UserDB.ToList();
            return Ok(dsUser);
        }


        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                var user = _context.UserDB.SingleOrDefault(us => us.Id == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);

            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create(UserModel userModel)
        {

            try
            {
                var user = new User
                {

                    Name = userModel.Name,
                    password = userModel.password
                };
                _context.Add(user);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, user);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, UserModel useredit)
        {
            try
            {
                var user = _context.UserDB.SingleOrDefault(us => us.Id == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }

                //update
                if (id != user.Id.ToString())
                {
                    return BadRequest();
                }
                user.Name = useredit.Name;
                user.password = useredit.password;
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var user = _context.UserDB.SingleOrDefault(us => us.Id == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }

                //update
                if (id != user.Id.ToString())
                {
                    return BadRequest();
                }


                _context.Remove(user);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
