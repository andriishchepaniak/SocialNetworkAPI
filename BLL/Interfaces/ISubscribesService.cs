using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubscribesService
    {
        Task<IEnumerable<UserDTO>> GetUserFollowers(int userId);
        Task<IEnumerable<UserDTO>> GetUserFollowings(int userId);
        Task<UserDTO> Follow(int currentUserId, int followUserId);
        Task<UserDTO> UnFollow(int currentUserId, int followUserId);
    }
}
