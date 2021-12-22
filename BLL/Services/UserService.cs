using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
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
        //private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserDTO> Create(UserDTO entity)
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
            await unitOfWork.UserRepository.Create(newUser);
            return entity;
        }

        public async Task<UserDTO> Delete(int id)
        {
            return mapper.Map<UserDTO>(await unitOfWork.UserRepository.Delete(id));
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return mapper.Map<IEnumerable<UserDTO>>(await unitOfWork.UserRepository.GetAll());
        }

        public async Task<UserDTO> GetById(int id)
        {
            return mapper.Map<UserDTO>(await unitOfWork.UserRepository.GetById(id));
        }
        public async Task<IEnumerable<UserDTO>> GetByName(string name)
        {
            return mapper.Map<IEnumerable<UserDTO>>(
                (await unitOfWork.UserRepository.GetAll())
                .Where(u => u.LastName.ToLower() == name.ToLower() 
                || u.LastName.ToLower().Contains(name.ToLower())
                || u.FirstName.ToLower() == name.ToLower() 
                || u.FirstName.ToLower().Contains(name.ToLower())));
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

        public async Task<UserDTO> Update(UserDTO entity)
        {
            var usr = mapper.Map<User>(entity);
            return mapper.Map<UserDTO>(await unitOfWork.UserRepository.Update(usr));
        }

        public async Task<int> GetUsersCount()
        {
            return await unitOfWork.UserRepository.GetUsersCount();
        }

        public async Task<IEnumerable<UserDTO>> GetUsers(int count)
        {
            return mapper
                .Map<IEnumerable<UserDTO>>(await unitOfWork.UserRepository.GetUsers(count));
        }
        public async Task<IEnumerable<UserDTO>> GetUsers(int offset, int count)
        {
            return mapper
                .Map<IEnumerable<UserDTO>>
                (await unitOfWork.UserRepository.GetUsers(offset, count));
        }

        public async Task<UserDTO> LogIn(string login, string password)
        {
            return mapper.Map<UserDTO>(await unitOfWork.UserRepository.Login(login, password));
        }

        public async Task<int> Subscribe(int currentUserId, int followUserId)
        {
            var CurrentUser = await unitOfWork.UserRepository.GetById(currentUserId);
            var FollowUser = await unitOfWork.UserRepository.GetById(followUserId);
            CurrentUser.Followings.Add(FollowUser);
            FollowUser.Followers.Add(CurrentUser);
            return await unitOfWork.SaveChanges();
        }
    }
}
