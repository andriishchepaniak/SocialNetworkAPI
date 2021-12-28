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
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PostService(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public async Task<PostDTO> Create(PostDTO post)
        {
            var res = (await _db.Posts.AddAsync(_mapper.Map<Post>(post))).Entity;
            await _db.SaveChangesAsync();
            return _mapper.Map<PostDTO>(res);
        }

        public async Task<int> Delete(int postId)
        {
            var post = _db.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (post != null)
            {
                _db.Posts.Remove(_mapper.Map<Post>(post));
            }
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<PostDTO>>(
                await _db.Posts
                .OrderBy(p => p.Likes.Count)
                .ToListAsync());
        }

        public async Task<IEnumerable<PostDTO>> GetAll(int offset, int count)
        {
            return _mapper.Map<IEnumerable<PostDTO>>(
                await _db.Posts
                .OrderBy(p => p.Likes.Count)
                .Skip(offset)
                .Take(count)
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .ToListAsync());
        }

        public async Task<PostDTO> GetById(int postId)
        {
            return _mapper.Map<PostDTO>(
                await _db.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == postId));
        }

        public async Task<IEnumerable<PostDTO>> GetUserPosts(int userId)
        {
            return _mapper.Map<IEnumerable<PostDTO>>(
                await _db.Posts
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.PublicatedTime)
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .ToListAsync());
        }

        public async Task<PostDTO> Update(PostDTO post)
        {
            _db.Posts.Update(_mapper.Map<Post>(post));
            await _db.SaveChangesAsync();
            return _mapper.Map<PostDTO>(await _db.Posts.FirstOrDefaultAsync(p => p.Id == post.Id));
        }
    }
}
