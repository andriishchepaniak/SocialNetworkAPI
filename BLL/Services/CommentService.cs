using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CommentService(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<CommentDTO> AddComment(CommentDTO comment)
        {
            var dbComment = (await _db.Comments.AddAsync(_mapper.Map<Comment>(comment))).Entity;
            var res = await _db.SaveChangesAsync();
            if(res != 0)
            {
                return _mapper.Map<CommentDTO>(dbComment);
            }
            return null;
        }

        public async Task<int> DeleteComment(int commentId)
        {
            var comment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            _db.Comments.Remove(comment);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentDTO>> GetPostComments(int postId)
        {
            return _mapper.Map<IEnumerable<CommentDTO>>(
                await _db.Comments
                .Where(c => c.PostId == postId)
                .Include(c => c.User)
                .ToListAsync()
                );
        }
    }
}
