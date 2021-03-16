using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Service.Services
{
    class ArticleLikeService:GenericService<ArticleLike,ArticleLikeDto>
    {
        public ArticleLikeService(IUnitOfWork unitOfWork, ArticleLikeRepository repository):base(unitOfWork,repository)
        {

        }
    }
}
