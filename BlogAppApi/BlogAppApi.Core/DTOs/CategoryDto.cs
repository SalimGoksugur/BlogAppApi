using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; }
        public int? ArticlesCount { get; set; }
    }
}
