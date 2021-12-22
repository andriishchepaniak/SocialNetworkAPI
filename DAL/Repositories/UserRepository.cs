using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;
        public UserRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await db.Users
                .Include(u => u.Adress)
                //.Include(u => u.Followers)
                //    .ThenInclude(follower => follower.Adress)
                //.Include(u => u.Followings)
                //    .ThenInclude(following => following.Adress)
                .ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await db.Users
                .Include(u => u.Adress)
                .Include(u => u.Followers)
                    .ThenInclude(follower => follower.Adress)
                .Include(u => u.Followings)
                    .ThenInclude(following => following.Adress)
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<User> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<User> Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<User> Find(int id)
        {
            return await db.Users.FindAsync(id);
        }
        public async Task<int> GetUsersCount()
        {
            return await db.Users.CountAsync();
        }

        public async Task<IEnumerable<User>> GetUsers(int count)
        {
            return await db.Users
                .Take(count)
                .ToListAsync();
        }
        public async Task<User> Login(string login, string password)
        {
            return await db.Users
                .FirstOrDefaultAsync(u => u.Email == login && u.Password == password);
        }
        public async Task<IEnumerable<User>> GetUsers(int offset, int count)
        {
            return await db.Users
                .Include(u => u.Adress)
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }
    }
}
