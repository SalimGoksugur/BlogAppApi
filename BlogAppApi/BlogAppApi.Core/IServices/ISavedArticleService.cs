using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface ISavedArticleService:IGenericService<SavedArticle, SavedArticleDto>
    {
        Task<Response<IEnumerable< SavedArticlesDto>>> GetSavedArticles(int userId,int pageNumber, int pageSize);
        Task<Response<NoDataDto>> SaveArticle(int userId, int articleId);
        Task<Response<NoDataDto>> RemoveArticle(int articleId);
        Task<SavedArticle> GetSavedArticle(int userId,int articleId);
    }
}
