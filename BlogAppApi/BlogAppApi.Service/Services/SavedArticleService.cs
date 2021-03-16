using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IRepositories;
using BlogAppApi.Core.IServices;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.Data.Repositories;
using BlogAppApi.SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class SavedArticleService:GenericService<SavedArticle, SavedArticleDto>, ISavedArticleService
    {
        private readonly ISavedArticlesRepository _repository;
       private readonly IUnitOfWork _unitOfWork;
        public SavedArticleService(IUnitOfWork unitOfWork, ISavedArticlesRepository repository) : base(unitOfWork, repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

     

        public async Task<Response<IEnumerable< SavedArticlesDto>>> GetSavedArticles(int userId, int pageNumber, int pageSize)
        {
            var result = await _repository.GetSavedArticles(userId, (pageNumber - 1) * pageSize, pageSize);
            return Response<IEnumerable<SavedArticlesDto>>.Success(ObjectMapper.
                Mapper.Map<IEnumerable< SavedArticlesDto>>(result), 200);
        }

        public async Task<SavedArticle> GetSavedArticle(int userId,int articleId)
        {
            return  _repository.Where(saved => saved.ArticleId == articleId && saved.UserId == userId).FirstOrDefault();
                            
        }

        public async Task<Response<NoDataDto>> RemoveArticle(int articleId)
        {
           await _repository.Remove(await _repository.GetByIdAsync(articleId));
            if(_unitOfWork.Save())
                return Response<NoDataDto>.Success(204);
            return Response<NoDataDto>.Fail("Kayıt sırasında bir hata oluştu", 500);
        }

        public async Task<Response<NoDataDto>> SaveArticle(int userId, int articleId)
        {
            await _repository.AddAsync(new SavedArticle {UserId=userId, ArticleId=articleId });
            if (_unitOfWork.Save())
                return Response<NoDataDto>.Success(201);
            return Response<NoDataDto>.Fail("Kayıt sırasında bir hata oluştu", 500);
        }

    }
}
