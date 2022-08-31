using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Models.ViewModel.Users;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;

        public UsersController( IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Ok(_UserRepository.GetAll());
            }catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var user = _UserRepository.GetById(id);
                if (user != null)
                {
                    return Ok(user);
                }
                  return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("{name},{password}")]
        //public IActionResult Login(string name, string password)
        //{
        //    try
        //    {
        //        var user = _UserRepository.Login(name, password);   
        //        if (user != null)
        //        {
        //            return Ok(user);
        //        }
        //        return NotFound();
        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        [HttpPut("{id}")]
        public IActionResult Update(UpdateUser user, Guid id)
        {
           
            try
            {
                _UserRepository.Update(user, id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
           
            try
            {
               _UserRepository.Delete(id);
                return Ok();
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(CreateUser user)
        {
            try
            {
                return Ok(_UserRepository.Add(user));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }
}
