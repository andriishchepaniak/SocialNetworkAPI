using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<IEnumerable<UserDTO>> GetAll(int offset, int count);
        Task<IEnumerable<UserDTO>> GetSortedByName();
        Task<IEnumerable<UserDTO>> GetUserFollowers(int userId);
        Task<IEnumerable<UserDTO>> GetUserFollowings(int userId);
        Task<UserDTO> GetById(int userId);
        Task<UserDTO> Create(UserDTO user);
        Task<UserDTO> Update(UserDTO user);
        Task<int> Delete(int userId);
    }
}
