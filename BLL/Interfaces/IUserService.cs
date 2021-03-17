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
        Task<UserDTO> Create(UserDTO entity);
        Task<UserDTO> Update(UserDTO entity);
        Task<UserDTO> Delete(int id);
        bool Login(string login, string password);
    }
}
