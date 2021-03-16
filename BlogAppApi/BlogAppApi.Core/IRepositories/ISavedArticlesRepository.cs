using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IRepositories
{
    public interface ISavedArticlesRepository:IGenericRepository<SavedArticle>
    {
        Task<bool> IsSavedByMe(int articleId, int userId);
        Task<IEnumerable<SavedArticle>> GetSavedArticles(int userId, int skipCount, int takeCount);
    }
}
