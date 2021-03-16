using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class CommentUpdateDto:BaseDto
    {
        public string Content { get; set; }
    }
}
