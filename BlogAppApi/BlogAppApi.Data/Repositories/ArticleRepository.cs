using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Data.Repositories
{
    public class ArticleRepository:GenericRepository<Article>, IArticleRepository
    {
        private readonly DbSet<Article> _dbSet;
        public ArticleRepository(AppDbContext context):base(context)
        {
            _dbSet = context.Set<Article>();
        }

        public IQueryable<Article> GetWithCommentAndLikesByIdAsync(int id)
        {
            return _dbSet.Include(art => art.Comments).Include(art => art.Likes).Where(art => art.Id == id);
        }

        public IQueryable<Article> GetArticlesByCategoryId(int categoryId, int skip, int take)
        {
            return _dbSet.Include(art => art.Comments).Include(art => art.Likes).Include(art => art.SavedArticles).
                Where(art => art.CategoryId == categoryId).Skip(skip).Take(take).OrderBy(art => art.PublishDate);
        }

      
    }
}
