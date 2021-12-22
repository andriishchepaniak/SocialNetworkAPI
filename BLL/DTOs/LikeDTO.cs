using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class LikeDTO
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
