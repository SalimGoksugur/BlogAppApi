using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class ArticleWithOtherContents
    {
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string Content { get; set; }
        public string PictureUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public int ViewCount { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
      
        public UserDto Author { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<ArticleLikeDto> Likes { get; set; }
        public ICollection<SavedArticleDto> SavedArticles { get; set; }
    }
}
