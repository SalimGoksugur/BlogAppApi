using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IRepositories
{
    public interface IArticleRepository:IGenericRepository<Article>
    {
        IQueryable<Article> GetWithCommentAndLikesByIdAsync(int id);
        IQueryable<Article> GetArticlesByCategoryId(int categoryId, int skip, int take);
    }
}
