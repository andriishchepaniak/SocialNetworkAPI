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
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            //Test all methods

            //var user = new User
            //{
            //    Id = 3,
            //    FirstName = "Scarlett",
            //    LastName = "Johanssson",
            //    Age = 37,
            //    Email = "scarlett@gmail.com",
            //    Password = "1111"
            //};
            //await Put(user);
            //await Delete(3);
            //await Post(user);
            return await db.Users.Include(u => u.Posts).Include(u => u.Adress).ToListAsync();
        }
        public async Task<ActionResult<User>> GetById(int id)
        {
            return await db.Users.Include(u => u.Posts).Include(u => u.Adress).FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<ActionResult<User>> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<ActionResult<User>> Update(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<ActionResult<User>> Delete(int id)
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
