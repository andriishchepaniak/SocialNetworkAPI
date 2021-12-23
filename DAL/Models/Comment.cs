using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public DateTime PublicatedTime { get; set; }
    }
}
