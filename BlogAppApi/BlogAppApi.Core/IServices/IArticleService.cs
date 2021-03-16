using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface IArticleService:IGenericService<Article, ArticleDto>
    {
        Task<Response<NoDataDto>> Update(ArticleUpdateDto articleUpdateDto);
        Task<Response<IEnumerable<ArticleDto>>> GetPaginatedByCategoryId(int categoryId, int pageNumber,
            int pageSize, int userId);
        Task UpdateViewCount(int articleId);
    }
}
