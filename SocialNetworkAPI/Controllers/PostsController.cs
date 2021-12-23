using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }
    }
}
