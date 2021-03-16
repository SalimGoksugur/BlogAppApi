using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class Comment:BaseEntity
    {
        public Comment()
        {

        }
        public Comment(int userId, string content, int articleId, int parComId)
        {
            this.UserId = userId;
            this.Content = content;
            this.ArticleId = articleId;
            this.ParentCommentId = parComId;
        }
        public Comment(int userId, string content, int articleId)
        {
            this.UserId = userId;
            this.Content = content;
            this.ArticleId = articleId;
        }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int? ArticleId { get; set; }
        public int? ParentCommentId { get; set; } 
        public ICollection<CommentLike> Likes { get; set; }
        public Comment ParentComment { get; set; }
        public ICollection<Comment> ChildComents { get; set; }
        public AppUser User { get; set; }
        public Article Article { get; set; }
    }
}
