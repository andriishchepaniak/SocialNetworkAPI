using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPostRepository
    {
        Task<ActionResult<IEnumerable<Post>>> GetAll();
        Task<ActionResult<Post>> GetById(int id);
        Task<ActionResult<Post>> Create(Post entity);
        Task<ActionResult<Post>> Update(Post entity);
        Task<ActionResult<Post>> Delete(int id);
    }
}
