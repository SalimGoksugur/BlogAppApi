using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface ICategoryService:IGenericService<Category, CategoryDto>
    {
        Task<Response<IEnumerable< CategoryWithArticlesDto>>> GetArticlesWithCommentAndLikesPaginated(int categoryId, int pageNumber, int pageSize);
        Task<Response<IEnumerable<CategoryDto>>> GetWithArticlesCount(); 
        Task<Response<CategoryDto>> GetWithArticlesCountByIdAsync(int id);

    }
}
