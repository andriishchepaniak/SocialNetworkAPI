using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDTO> AddComment(CommentDTO comment);
        Task<int> DeleteComment(int commentId);
        Task<IEnumerable<CommentDTO>> GetPostComments(int postId);
    }
}
