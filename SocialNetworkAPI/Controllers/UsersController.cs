using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
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
    public class UsersController : ControllerBase
    {
        //private readonly ApplicationDbContext db;
        //private readonly IRepository<User> userRepository;
        private readonly IService<User> userService;
        public UsersController(IService<User> service)
        {
            userService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            //Test all REST methods

            //var user = new User
            //{
            //    Id = 5,
            //    FirstName = "Quentin",
            //    LastName = "Tarantino",
            //    Age = 57,
            //    Email = "tarantino@gmail.com",
            //    Password = "1111",
            //    Adress = new Adress
            //    {
            //        Country = "USA",
            //        City = "Los Angeles"
            //    }
            //};
            //await Put(user);
            //await Delete(3);
            //await Post(user);

            return await userService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await userService.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            await userService.Create(user);
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            await userService.Update(user);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = userService.GetById(id);
            if(user == null)
            {
                return NotFound();
            }
            await userService.Delete(id);
            return Ok(user);
        }
    }
}
