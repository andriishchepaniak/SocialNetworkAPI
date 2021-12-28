using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;
        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }
        [AllowAnonymous]
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostLikes(int postId)
        {
            var result = await _likeService.GetPostLikes(postId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPost("addLike")]
        public async Task<IActionResult> AddLike([FromBody] LikeDTO like)
        {
            var result = await _likeService.AddLike(like);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpDelete("{likeId}")]
        public async Task<IActionResult> DeleteLike(int likeId)
        {
            var result = await _likeService.DeleteLike(likeId);
            return result != 0
                ? Ok(result)
                : BadRequest();
        }
    }
}
