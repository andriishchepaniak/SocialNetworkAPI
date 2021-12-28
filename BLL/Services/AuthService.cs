using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public AuthService(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<object> Login(LoginUserDTO loginUser)
        {
            var identity = await GetIdentity(loginUser.Email, loginUser.Password);
            if (identity == null)
            {
                throw new ArgumentException("Invalid username or password.");
            }

            var jwt = GenerateSecurityToken(AuthOptions.ISSUER, AuthOptions.AUDIENCE, identity);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            //return JsonSerializer.Serialize(response);
            return response;
        }

        public async Task<object> Register(RegisterUserDTO registerUser)
        {
            var person = await _db.Users
                .FirstOrDefaultAsync(e => e.Email == registerUser.Email);

            if (person != null)
            {
                throw new ArgumentException("Email is already taken.");
            }

            //var dbUser = _mapper.Map<User>(registerUser);
            var newUser = (await _db.Users.AddAsync(_mapper.Map<User>(registerUser))).Entity;
            var saveRes = await _db.SaveChangesAsync();
            if(saveRes != 0)
            {
                var loginUser = new LoginUserDTO()
                {
                    Email = newUser.Email,
                    Password = newUser.Password
                };
                return await Login(loginUser);
            }
            return null;
        }

        private static JwtSecurityToken GenerateSecurityToken(string ISSUER, string AUDIENCE, ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return jwt;
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var person = _mapper.Map<UserDTO>(await _db.Users
                .FirstOrDefaultAsync(e => e.Email == username));

            var checkPassword = await CheckPasswordAsync(person, password);

            if (person != null || checkPassword)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, person.Id.ToString()),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }

        private Task<bool> CheckPasswordAsync(UserDTO person, string password)
        {
            if (password != null && person.Password == password)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
