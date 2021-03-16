using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class Article:BaseEntity
    {
        public Article()
        {
                
        }
        public Article(string title, string cSummary, string content, string picUrl, int categoryId)
        {
            this.Title = title;
            this.ContentSummary = cSummary;
            this.Content = content;
            this.PictureUrl = picUrl;
            this.CategoryId = categoryId;
        }
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string Content { get; set; }
        public string PictureUrl { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public int ViewCount { get; set; } = 0;
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public AppUser Author { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ArticleLike> Likes { get; set; }
        public ICollection<SavedArticle> SavedArticles { get; set; }
    }
}
