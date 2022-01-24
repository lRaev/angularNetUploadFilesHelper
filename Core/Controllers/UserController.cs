using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TransactionDbContext _dbContext;
        public UserController(TransactionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            return  Ok(users);
        }

        [HttpPost]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult CreateUser([FromBody]User user)
        {
            try
            {
                if(user == null)
                {
                    return BadRequest("User cannot be null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid Model");
                
                }

                user.Id = Guid.NewGuid();
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return StatusCode(201);


            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}