using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly ApplicationDbContext db;
        //private readonly IRepository<User> userRepository;
        private readonly IUserService userService;
        public UsersController(IUserService service)
        {
            userService = service;
        }
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var result = await userService.GetAll();
            var jsonData = new
            {
                data = result,
                count = 10
            };

            var res = new JsonResult(jsonData);
            return res;
            //var result = Get(2);
            //return result;
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await userService.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(UserDTO user)
        {
            await userService.Create(user);
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<UserDTO>> Put(UserDTO user)
        {
            if (user == null)
            {
                return NotFound();
            }
            await userService.Update(user);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
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
