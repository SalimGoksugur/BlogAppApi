using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class CommentLikeDto:BaseDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
    }
}
