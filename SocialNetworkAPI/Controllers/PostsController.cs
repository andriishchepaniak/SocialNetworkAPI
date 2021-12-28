using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _postService.GetAll();
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [AllowAnonymous]
        [Route("getbypages")]
        [HttpGet]
        public async Task<IActionResult> GetByPages(int offset, int count)
        {
            var result = await _postService.GetAll(offset, count);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [AllowAnonymous]
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetById(int postId)
        {
            var result = await _postService.GetById(postId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [AllowAnonymous]
        [HttpGet("userposts/{userId}")]
        public async Task<IActionResult> GetUserPosts(int userId)
        {
            var result = await _postService.GetUserPosts(userId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDTO post)
        {
            var currentUserId = Convert.ToInt32(User.Identity.Name);
            post.UserId = currentUserId;
            var result = await _postService.Create(post);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PostDTO post)
        {
            var result = await _postService.Update(post);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int postId)
        {
            var result = await _postService.Delete(postId);
            return result != 0
                ? Ok(result)
                : BadRequest();
        }
    }
}
