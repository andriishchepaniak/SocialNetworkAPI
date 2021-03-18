using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Range(1, 150, ErrorMessage = "Age must be > 0")]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
        public Adress Adress { get; set; }
        public List<Post> Posts { get; set; }

        public List<User> Followers { get; set; }
        public List<User> Followings { get; set; }
    }
}
