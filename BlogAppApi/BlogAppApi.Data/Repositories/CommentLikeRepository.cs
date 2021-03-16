using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Repositories
{
    public class CommentLikeRepository:GenericRepository<CommentLike>
    {
        public CommentLikeRepository(AppDbContext context):base(context)
        {

        }
    }
}
