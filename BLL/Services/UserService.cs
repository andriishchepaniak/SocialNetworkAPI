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
            var result = (await _db.Users.AddAsync(_mapper.Map<User>(user))).Entity;
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDTO>(result);
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

        

        public async Task<UserDTO> Update(UserDTO user)
        {
            var result = _db.Users.Update(_mapper.Map<User>(user)).Entity;
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDTO>(result);
        }
    }
}
