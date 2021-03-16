using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
   public class SavedArticlesDto:BaseDto
    {
     
        public DateTime SaveDate { get; set; }
        public ArticleDto ArticleDto;
    }
}
