using BLL.DTOs;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Web.Http.Results;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Test all REST methods
            //var post = await Get(3);
            //post.Text = "I am iron man";
            //var user = new User
            //{
            //    Id = 3,
            //    FirstName = "Scarlett",
            //    LastName = "Johanssson",
            //    Age = 37,
            //    Email = "scarlett@gmail.com",
            //    Password = "1111"
            //};
            //await Put(post);
            //await Delete(3);
            //await Post(user);

            var result = await postService.GetAll();
             
            return result != null 
                ? new JsonResult(result) 
                : (IActionResult)BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<PostDTO> Get(int id)
        {
            var result = await postService.GetById(id);
            return result != null
                ? result
                : null;
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDTO post)
        {
            var result = await postService.Create(post);
            return result != null
                ? CreatedAtAction(nameof(Post), post)
                : (IActionResult)BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(PostDTO post)
        {
            var result = await postService.Update(post);
            return result != null
                ? NoContent()
                : (IActionResult)BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            await postService.Delete(id);
            return NoContent();
        }
    }
}
