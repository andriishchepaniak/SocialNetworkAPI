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
            return Ok(await _userService.GetAll());
        }
        [Route("getbypages")]
        [HttpGet]
        public async Task<IActionResult> GetByPages(int offset, int count)
        {
            return Ok(await _userService.GetAll(offset, count));
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            return Ok(await _userService.GetById(userId));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
            return Ok(await _userService.Create(user));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDTO user)
        {
            return Ok(await _userService.Update(user));
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            return Ok(await _userService.Delete(userId));
        }
    }
}
