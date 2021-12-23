using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
