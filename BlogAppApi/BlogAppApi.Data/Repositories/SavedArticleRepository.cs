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
    public class SavedArticleRepository:GenericRepository<SavedArticle>, ISavedArticlesRepository
    {
        private readonly DbSet<SavedArticle> _dbSet;
        public SavedArticleRepository(AppDbContext context):base(context)
        {
            _dbSet = context.Set<SavedArticle>();
        }

        public async Task<IEnumerable<SavedArticle>> GetSavedArticles(int userId, int skipCount, int takeCount)
        {
            return await _dbSet.Include(savedArt => savedArt.Article).Where(savedArt => savedArt.UserId == userId).
                Skip(skipCount).Take(takeCount).OrderBy(savedArt => savedArt.SaveDate).ToListAsync();
        }

        public async Task<bool> IsSavedByMe(int articleId, int userId)
        {
          SavedArticle article=await  _dbSet.Where(savedArt => savedArt.ArticleId == articleId && savedArt.UserId == userId).FirstOrDefaultAsync();
            if (article != null)
                return true;
            return false;
        }
    }
}
