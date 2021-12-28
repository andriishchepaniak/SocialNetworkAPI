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
    public class SubscribesController : ControllerBase
    {
        private readonly ISubscribesService _subscribesService;
        public SubscribesController(ISubscribesService subscribesService)
        {
            _subscribesService = subscribesService;
        }
        [AllowAnonymous]
        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetUserFollowers(int userId)
        {
            var result = await _subscribesService.GetUserFollowers(userId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [AllowAnonymous]
        [HttpGet("{userId}/followings")]
        public async Task<IActionResult> GetUserFollowings(int userId)
        {
            var result = await _subscribesService.GetUserFollowings(userId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPost("follow/{userId}")]
        public async Task<IActionResult> Follow(int userId)
        {
            var currentUserId = Convert.ToInt32(User.Identity.Name);
            var result = await _subscribesService.Follow(currentUserId, userId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPost("unfollow/{userId}")]
        public async Task<IActionResult> UnFollow(int userId)
        {
            var currentUserId = Convert.ToInt32(User.Identity.Name);
            var result = await _subscribesService.UnFollow(currentUserId, userId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
    }
}
