using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class SavedArticle:BaseEntity
    {
        public SavedArticle()
        {

        }
        public SavedArticle(int artId, int userId)
        {
            this.ArticleId = artId;
            this.UserId = userId;
        }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public DateTime SaveDate { get; set; } = DateTime.Now;
        public Article Article { get; set; }
        public AppUser User { get; set; }
    }
}
