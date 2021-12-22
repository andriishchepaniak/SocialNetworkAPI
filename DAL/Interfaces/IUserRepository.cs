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
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User entity);
        Task<User> Update(User entity);
        Task<User> Delete(int id);
        Task<int> GetUsersCount();
        Task<User> Login(string login, string password);
        Task<IEnumerable<User>> GetUsers(int count);
        Task<IEnumerable<User>> GetUsers(int offset, int count);
    }
}
