using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<ActionResult<IEnumerable<User>>> GetAll();
        public Task<ActionResult<User>> GetById(int id);
        public Task<ActionResult<User>> Create(User entity);
        public Task<ActionResult<User>> Update(User entity);
        public Task<ActionResult<User>> Delete(int id);
        
    }
}
