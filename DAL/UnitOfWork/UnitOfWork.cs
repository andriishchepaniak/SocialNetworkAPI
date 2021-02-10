using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IPostRepository PostRepository { get; }

        public UnitOfWork(IUserRepository userRepository, IPostRepository postRepository)
        {
            UserRepository = userRepository;
            PostRepository = postRepository;
        }
    }
}
