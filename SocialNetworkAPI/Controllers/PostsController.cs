using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService postService;
        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var result = await postService.GetAllPostsByUserId(userId);
             
            return result != null 
                ? new JsonResult(result) 
                : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await postService.GetAll();
             
            return result != null 
                ? new JsonResult(result) 
                : BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await postService.GetById(id);
            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(PostDTO post)
        {
            var result = await postService.Create(post);
            return result != null
                ? new JsonResult(result)
                : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(PostDTO post)
        {
            var result = await postService.Update(post);
            return result != null
                ? NoContent()
                : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            await postService.Delete(id);
            return NoContent();
        }
    }
}
