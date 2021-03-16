using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class CommentDto:BaseDto
    {
        public int? UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ArticleId { get; set; }
        public int? ParentCommentId { get; set; }
        public int LikeCount { get; set; }
        public CommentDto ParentComment { get; set; }
        public ICollection<CommentDto> ChildComents { get; set; }
        public UserDto User { get; set; }
    }
}
