using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<UserDTO> Create(UserDTO user)
        {
            await _db.Users.AddAsync(_mapper.Map<User>(user));
            await _db.SaveChangesAsync();
            var res = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            return _mapper.Map<UserDTO>(res);
        }

        public async Task<int> Delete(int userId)
        {
            var user = _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if(user != null)
            {
                _db.Users.Remove(_mapper.Map<User>(user));
            }
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _db.Users.ToListAsync());
        }

        public async Task<IEnumerable<UserDTO>> GetAll(int offset = 0, int count = 10)
        {
            return _mapper.Map<IEnumerable<UserDTO>>(
                await _db.Users
                    .Skip(offset)
                    .Take(count)
                    .ToListAsync());
        }

        public async Task<UserDTO> GetById(int userId)
        {
            return _mapper.Map<UserDTO>(
                await _db.Users.FirstOrDefaultAsync(u => u.Id == userId));
        }

        public async Task<IEnumerable<UserDTO>> GetSortedByName()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(
                await _db.Users
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync());
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

        public async Task<UserDTO> Update(UserDTO user)
        {
            _db.Users.Update(_mapper.Map<User>(user));
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDTO>(await _db.Users.FirstOrDefaultAsync(u => u.Id == user.Id));
        }
    }
}
