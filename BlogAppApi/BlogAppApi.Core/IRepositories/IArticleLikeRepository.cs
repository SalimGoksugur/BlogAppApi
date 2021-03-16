using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IRepositories
{
    public interface IArticleLikeRepository
    {
        Task<int> GetLikeCountByArticleId(int articleId);
        Task<bool> IsLikedByMe(int articleId, int userId);
    }
}
