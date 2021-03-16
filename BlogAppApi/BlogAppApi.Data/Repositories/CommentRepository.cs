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
    public class CommentRepository:GenericRepository<Comment>, ICommentRepository
    {
        private readonly DbSet<Comment> _dbSet;
        public CommentRepository(AppDbContext context):base(context)
        {
            _dbSet = context.Set<Comment>();
        }

        public async Task< IEnumerable<Comment>> GetCommentsByArticleId(int articleId, int skipCount, int takeCount)
        {
            return await _dbSet.Where(comment => comment.ArticleId == articleId).Skip(skipCount).Take(takeCount).
                OrderBy(comment => comment.Date).ToListAsync();
        }
    }
}
