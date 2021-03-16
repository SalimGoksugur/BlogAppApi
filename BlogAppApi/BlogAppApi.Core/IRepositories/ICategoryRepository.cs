using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IRepositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        IQueryable<Category> GetArticlesWithCommentAndLikesPaginated(int categoryId, int countToSkip, int countToTake);
        IQueryable GetWithArticlesCount();
        Task<Category> GetWithArticlesCountByIdAsync(int id);
    }
}
