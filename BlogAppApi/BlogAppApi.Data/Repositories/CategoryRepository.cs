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
    public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _dbSet;
        public CategoryRepository(AppDbContext context):base(context)
        {
            _dbSet = context.Set<Category>();
        }

        public IQueryable<Category> GetArticlesWithCommentAndLikesPaginated(int categoryId, int countToSkip, int countToTake)
        {

            //var result=  _dbSet.Include(category => category.Articles)
            //     .ThenInclude(art=>art.Comments).
            //    Include(cat=>cat.Articles).ThenInclude(art=>art.Likes)
            //    .Where(cat => cat.Id == id).Skip(countToSkip).Take(countToTake);
            var result = _dbSet.Include(cat => cat.Articles).ThenInclude(art => art.Comments).
                 Include(cat => cat.Articles).ThenInclude(art => art.Likes).
                Where(cat => cat.Id == categoryId).Skip(countToSkip).Take(countToTake);

            return result;
        }

        public IQueryable GetWithArticlesCount()
        {
            return _dbSet.Include(cat => cat.Articles).OrderBy(cat=>cat.Name);
        }

        public async Task<Category> GetWithArticlesCountByIdAsync(int id)
        {
            return await _dbSet.Include(cat => cat.Articles).Where(cat => cat.Id == id).FirstOrDefaultAsync();
        }
    }
}
