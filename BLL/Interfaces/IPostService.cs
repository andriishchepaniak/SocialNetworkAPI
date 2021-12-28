using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetAll();
        Task<IEnumerable<PostDTO>> GetAll(int offset, int count);
        Task<IEnumerable<PostDTO>> GetUserPosts(int userId);
        Task<PostDTO> GetById(int postId);
        Task<PostDTO> Create(PostDTO post);
        Task<PostDTO> Update(PostDTO post);
        Task<int> Delete(int postId);
    }
}
