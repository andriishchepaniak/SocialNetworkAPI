using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await db.Users.Include(u => u.Adress)
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
    }
}
