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
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext db;
        public PostRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await db.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .ToListAsync();
        }
        public async Task<Post> GetById(int id)
        {
            return await db.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(post => post.Id == id);
        }
        public async Task<IEnumerable<Post>> GetAllPostsByUserId(int id)
        {
            return await db.Posts
                .Where(p => p.User.Id == id)
                .Include(p => p.User)
                .ToListAsync();
        }
        public async Task<Post> Create(Post post)
        {
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return post;
        }
        public async Task<Post> Update(Post post)
        {
            db.Posts.Update(post);
            await db.SaveChangesAsync();
            return post;
        }
        public async Task<Post> Delete(int id)
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
