using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublicatedTime { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public List<LikeDTO> Likes { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
