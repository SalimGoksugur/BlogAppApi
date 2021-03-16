using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlogAppApi.Core.DTOs
{
    public class ArticleUpdateDto:BaseDto
    {
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string Content { get; set; }     
        public int CategoryId { get; set; }
    }
}
