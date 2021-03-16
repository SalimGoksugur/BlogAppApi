using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlogAppApi.Core.DTOs
{
    public class ArticleCreateDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}
