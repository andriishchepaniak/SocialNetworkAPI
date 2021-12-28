using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AdressDTO Adress { get; set; }
    }
}
