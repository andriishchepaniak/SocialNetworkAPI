using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime PublicatedTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}