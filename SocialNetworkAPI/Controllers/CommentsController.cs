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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [AllowAnonymous]
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostComments(int postId)
        {
            var result = await _commentService.GetPostComments(postId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentDTO comment)
        {
            var result = await _commentService.AddComment(comment);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteLike(int commentId)
        {
            var result = await _commentService.DeleteComment(commentId);
            return result != 0
                ? Ok(result)
                : BadRequest();
        }
    }
}
