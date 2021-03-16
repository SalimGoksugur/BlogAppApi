using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class CommentLike:BaseEntity
    {
        public CommentLike()
        {

        }
        public CommentLike(int userId, int commentId)
        {
            this.UserId = userId;
            this.CommentId = commentId;
        }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public AppUser User { get; set; }
        public Comment Comment { get; set; }

    }
}
