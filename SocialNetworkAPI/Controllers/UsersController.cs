using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.DTOs;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService service)
        {
            userService = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(int offset = 0, int count = 10)
        {
            var result = new
            {
                items = await userService.GetUsers(offset, count),               
                totalUsersCount = await userService.GetUsersCount()
            };

            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            var result = await userService.GetUsersCount();
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await userService.GetById(id);
            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        [HttpGet("search/{search}")]
        public async Task<IActionResult> SearchUser(string search)
        {
            var result = await userService.GetByName(search);
            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var result = await userService.LogIn(loginUser.Login, loginUser.Password);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpGet("count={count}")]
        public async Task<IActionResult> GetUsers(int count)
        {
            var result = await userService.GetUsers(count);
            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        [HttpGet("offset={offset}&count={count}")]
        public async Task<IActionResult> GetUsers(int offset, int count)
        {
            var result = await userService.GetUsers(offset, count);
            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserDTO user)
        {
            var result = await userService.Update(user);
            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(UserDTO user)
        {
            var result = await userService.Create(user);
            return result != null
                ? NoContent()
                : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.Delete(id);
            return result != null
                ? NoContent()
                : BadRequest();
        }
    }
}
