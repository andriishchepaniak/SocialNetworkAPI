using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IService<User>
    {
        private readonly IUserRepository userRepository;
        
        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }

        public async Task<ActionResult<User>> Create(User entity)
        {
            var newUser = new User
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Email = entity.Email,
                Password = Hash(entity.Password),
                Adress = new Adress
                {
                    Country = entity.Adress.Country,
                    City = entity.Adress.City
                }
            };
            return await userRepository.Create(newUser);
        }

        public async Task<ActionResult<User>> Delete(int id)
        {
            return await userRepository.Delete(id);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await userRepository.GetAll();
        }

        public async Task<ActionResult<User>> GetById(int id)
        {
            return await userRepository.GetById(id);
        }
        private string Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256Hash.ComputeHash(passwordBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hash;
            }
        }
        public bool Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<User>> Update(User entity)
        {
            return await userRepository.Update(entity);
        }
    }
}
