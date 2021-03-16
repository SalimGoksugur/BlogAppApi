using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IRepositories
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByArticleId(int articleId, int skipCount, int takeCount);
    }
}
