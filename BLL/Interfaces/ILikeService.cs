using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILikeService
    {
        Task<LikeDTO> AddLike(LikeDTO like);
        Task<int> DeleteLike(int likeId);
        Task<IEnumerable<LikeDTO>> GetPostLikes(int postId);
    }
}
