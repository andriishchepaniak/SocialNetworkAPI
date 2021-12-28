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
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public LikeService(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<LikeDTO> AddLike(LikeDTO like)
        {
            var dbLike = (await _db.Likes.AddAsync(_mapper.Map<Like>(like))).Entity;
            await _db.SaveChangesAsync();
            return _mapper.Map<LikeDTO>(dbLike);
        }

        public async Task<int> DeleteLike(int likeId)
        {
            var dbLike = await _db.Likes.FirstOrDefaultAsync(l => l.Id == likeId);
            _db.Likes.Remove(dbLike);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<LikeDTO>> GetPostLikes(int postId)
        {
            return _mapper.Map<IEnumerable<LikeDTO>>(
                await _db.Likes
                .Where(l => l.PostId == postId)
                .Include(l => l.User)
                .ToListAsync()
                );
        }
    }
}
