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
        public Task<IEnumerable<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> Create(User entity);
        public Task<User> Update(User entity);
        public Task<User> Delete(int id);
        
    }
}
