using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class CategoryUpdateDto:BaseDto
    {
        public string Name { get; set; }
    }
}
