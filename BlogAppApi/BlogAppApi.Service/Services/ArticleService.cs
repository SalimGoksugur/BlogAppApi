using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IRepositories;
using BlogAppApi.Core.IServices;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.Data.Repositories;
using BlogAppApi.SharedLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class ArticleService:GenericService<Article, ArticleDto>,IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _repository;
        private readonly IArticleLikeRepository _articleLikeRepo;
        private readonly ISavedArticlesRepository _savedArtRepo;
        public ArticleService(IUnitOfWork unitOfWork, IArticleRepository repository,
            IArticleLikeRepository articleLikeRepository, ISavedArticlesRepository savedArtRepo) : base(unitOfWork, repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _articleLikeRepo = articleLikeRepository;
            _savedArtRepo = savedArtRepo;
        }

        public async Task<Response<NoDataDto>> Update(ArticleUpdateDto articleUpdateDto)
        {
            Article article =await _repository.GetByIdAsync(articleUpdateDto.Id);
            if (article == null)
            {
                return Response<NoDataDto>.Fail("Makale bulunamadı", 400);
            }
            article.Title = articleUpdateDto.Title;
            article.ContentSummary = articleUpdateDto.ContentSummary;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;
            
            _repository.Update(article);
             if (_unitOfWork.Save())
                return Response<NoDataDto>.Success(200);
            return Response<NoDataDto>.Fail("Kayıt sırasında bir hata oluştu. Tekrar deneyiniz.", 500);
        }

        public async Task<Response<IEnumerable<ArticleDto>>> GetPaginatedByCategoryId(int categoryId, int pageNumber,
            int pageSize, int userId)
        {
            var result = _repository.GetArticlesByCategoryId(categoryId, pageSize * (pageNumber - 1), pageSize);
            var dto = ObjectMapper.Mapper.Map<IEnumerable<ArticleDto>>(result);
            foreach(var item in dto)
            {
                    item.LikedByMe = await _articleLikeRepo.IsLikedByMe(item.Id, userId);              
                    item.SavedByMe = await _savedArtRepo.IsSavedByMe(item.Id, userId);
            }
            
            return Response<IEnumerable<ArticleDto>>.Success(dto, 200);
        }

        public async Task UpdateViewCount(int articleId)
        {
            Article article=await _repository.GetByIdAsync(articleId);
            if (article != null)
            {
                article.ViewCount++;
                _repository.Update(article);
                _unitOfWork.Save();
            }

        }
    }
}
