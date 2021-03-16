using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Service.Services
{
    public class CommentLikeService:GenericService<CommentLike, CommentLikeDto>
    {
        public CommentLikeService(IUnitOfWork unitOfWork, CommentLikeRepository repository) : base(unitOfWork, repository)
        {

        }
    }
}
