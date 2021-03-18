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
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetAllPostsByUserId(int id);
        Task<Post> Create(Post entity);
        Task<Post> Update(Post entity);
        Task<Post> Delete(int id);
    }
}
