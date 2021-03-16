using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class CategoryWithArticlesDto:BaseDto
    {
        public string Name { get; set; }
        public virtual IEnumerable<ArticleDto> Articles { get; set; }
    }
}
