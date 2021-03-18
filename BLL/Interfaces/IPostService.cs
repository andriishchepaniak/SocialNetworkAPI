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
        Task<PostDTO> GetById(int id);
        Task<IEnumerable<PostDTO>> GetAllPostsByUserId(int id);
        Task<PostDTO> Create(PostDTO post);
        Task<PostDTO> Update(PostDTO post);
        Task<PostDTO> Delete(int id);
    }
}
