using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class ArticleDto:BaseDto
    {
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string Content { get; set; }
        public string PictureUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int ViewCount { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }      
        public bool SavedByMe { get; set; }
        public bool LikedByMe { get; set; }
        public DateTime? SaveDate { get; set; }
    }
}
