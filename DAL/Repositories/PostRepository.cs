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
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext db;
        public PostRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
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
            return await db.Posts.ToListAsync();
        }
        public async Task<ActionResult<Post>> GetById(int id)
        {
            return await db.Posts.FirstOrDefaultAsync(post => post.Id == id);
        }
        public async Task<ActionResult<Post>> Create(Post post)
        {
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return post;
        }
        public async Task<ActionResult<Post>> Update(Post post)
        {
            db.Posts.Update(post);
            await db.SaveChangesAsync();
            return post;
        }
        public async Task<ActionResult<Post>> Delete(int id)
        {
            var post = db.Posts.Find(id);
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return post;
        }
        public async Task<Post> Find(int id)
        {
            return await db.Posts.FindAsync(id);
        }
    }
}
