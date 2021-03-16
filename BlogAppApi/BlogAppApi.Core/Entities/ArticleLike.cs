using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class ArticleLike:BaseEntity
    {
        public ArticleLike()
        {

        }
        public ArticleLike(int userId, int articleId)
        {
            this.UserId = userId;
            this.ArticleId = articleId;
        }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public AppUser User { get; set; }
        public Article Article { get; set; }
    }
}
