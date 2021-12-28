using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using DAL;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [Route("getbypages")]
        [HttpGet]
        public async Task<IActionResult> GetByPages(int offset, int count)
        {
            var result = await _userService.GetAll(offset, count);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await _userService.GetById(userId);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
            var result = await _userService.Create(user);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDTO user)
        {
            var result = await _userService.Update(user);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _userService.Delete(userId);
            return result != 0
                ? Ok(result)
                : BadRequest();
        }
    }
}
