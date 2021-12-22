using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext db { get; set; }
        public IUserRepository UserRepository { get; }

        public IPostRepository PostRepository { get; }

        public UnitOfWork(
            IUserRepository userRepository, 
            IPostRepository postRepository,
            ApplicationDbContext context)
        {
            UserRepository = userRepository;
            PostRepository = postRepository;
            db = context;
        }
        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }
    }
}
