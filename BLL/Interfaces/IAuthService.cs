using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        Task<object> Login(LoginUserDTO loginUser);
        Task<object> Register(RegisterUserDTO registerUser);
    }
}
