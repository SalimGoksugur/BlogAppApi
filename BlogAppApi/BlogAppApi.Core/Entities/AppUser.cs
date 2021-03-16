using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public ICollection<Article> Articles { get; set; }
        public ICollection<ArticleLike> ArticleLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
        public ICollection<SavedArticle> SavedArticles { get; set; }
        public SecurityCode SecurityCode { get; set; }
        public UserRefreshToken RefreshToken { get; set; }
    }
}
