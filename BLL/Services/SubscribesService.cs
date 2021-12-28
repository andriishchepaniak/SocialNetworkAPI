using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubscribesService : ISubscribesService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public SubscribesService(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetUserFollowers(int userId)
        {
            var user = await _db.Users
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return _mapper.Map<IEnumerable<UserDTO>>(user.Followers.ToList());
        }
        public async Task<IEnumerable<UserDTO>> GetUserFollowings(int userId)
        {
            var user = await _db.Users
                .Include(u => u.Followings)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return _mapper.Map<IEnumerable<UserDTO>>(user.Followings.ToList());
        }
        public async Task<UserDTO> Follow(int currentUserId, int followUserId)
        {
            var currentUser = await _db.Users
                .Include(u => u.Followings)
                .FirstOrDefaultAsync(u => u.Id == currentUserId);
            var followUser = await _db.Users
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == followUserId);
            currentUser.Followings.Add(followUser);
            followUser.Followers.Add(currentUser);
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDTO>(followUser);
        }
        public async Task<UserDTO> UnFollow(int currentUserId, int followUserId)
        {
            var currentUser = await _db.Users
                .Include(u => u.Followings)
                .FirstOrDefaultAsync(u => u.Id == currentUserId);
            var followUser = await _db.Users
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == followUserId);
            currentUser.Followings.Remove(followUser);
            followUser.Followers.Remove(currentUser);
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDTO>(followUser);
        }
    }
}
