using Core.Data;
using Core.Models;
using Core.Services;
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

        public async Task<ActionResult<ServiceResponce<string>>> CreateUser([FromBody]User user)
        {
            var responce = new ServiceResponce<string>();
            try
            {
                if(user == null)
                {
                    responce.Message = "Not found";
                    responce.Data = "User not founf";
                    return responce;
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid Model");
                
                }

                user.Id = Guid.NewGuid();
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                responce.Data = "";
                responce.Success = true;
                return responce;


            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}