using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class CommentDTO
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public PostDTO Post { get; set; }
        public int PostId { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public DateTime PublicatedTime { get; set; }
    }
}
