using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class UserDto:BaseDto
    {
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public ICollection<ArticleDto> Articles { get; set; }
        public ICollection<SavedArticleDto> SavedArticles { get; set; }
    }
}
