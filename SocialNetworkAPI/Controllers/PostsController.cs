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

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly IPostRepository postRepository;
        public PostsController(ApplicationDbContext context, IPostRepository postRepository)
        {
            db = context;
            this.postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            //Test all REST methods

            //var user = new User
            //{
            //    Id = 3,
            //    FirstName = "Scarlett",
            //    LastName = "Johanssson",
            //    Age = 37,
            //    Email = "scarlett@gmail.com",
            //    Password = "1111"
            //};
            //await Put(user);
            //await Delete(3);
            //await Post(user);
            
            return await postRepository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            return await postRepository.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult<Post>> Post(Post post)
        {
            await postRepository.Create(post);
            return Ok(post);
        }
        [HttpPut]
        public async Task<ActionResult<User>> Put(Post post)
        {
            if (post == null)
            {
                return NotFound();
            }
            await postRepository.Update(post);
            return Ok(post);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            await postRepository.Delete(id);
            return Ok(post);
        }
    }
}
