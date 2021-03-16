using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface ICommentService:IGenericService<Comment, CommentDto>
    {
        Task <Response<IEnumerable<CommentDto>>> GetCommentsByArticleId(int articleId, int pageNumber);
    }
}
