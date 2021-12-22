using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task<IEnumerable<UserDTO>> GetByName(string name);
        Task<UserDTO> Create(UserDTO entity);
        Task<UserDTO> Update(UserDTO entity);
        Task<UserDTO> Delete(int id);
        Task<int> GetUsersCount();
        Task<IEnumerable<UserDTO>> GetUsers(int count);
        Task<IEnumerable<UserDTO>> GetUsers(int offset, int count);
        bool Login(string login, string password);
        Task<UserDTO> LogIn(string login, string password);
        Task<int> Subscribe(int currentUserId, int followUserId);

    }
}
