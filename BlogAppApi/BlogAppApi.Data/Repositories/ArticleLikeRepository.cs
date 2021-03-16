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
    public class ArticleLikeRepository:GenericRepository<ArticleLike>, IArticleLikeRepository
    {
        private readonly DbSet<ArticleLike> _dbSet;
        public ArticleLikeRepository(AppDbContext context):base(context)
        {
            _dbSet = context.Set<ArticleLike>();
        }

        public async Task<int> GetLikeCountByArticleId(int articleId)
        {
            return await _dbSet.Where(row => row.ArticleId == articleId).CountAsync();
        }

        public  async Task<bool> IsLikedByMe(int articleId, int userId)
        {
            var result = await _dbSet.Where(like => like.ArticleId == articleId && like.UserId == userId).FirstOrDefaultAsync();
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
