using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IRepositories;
using BlogAppApi.Core.IServices;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.Data.Repositories;
using BlogAppApi.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class CategoryService:GenericService<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository repository, IArticleRepository articleRepository) 
            : base(unitOfWork, repository)
        {
            _categoryRepository = repository;
        }

        public async Task<Response<IEnumerable<CategoryWithArticlesDto>>> GetArticlesWithCommentAndLikesPaginated(int categoryId, int pageNumber, int pageSize)
        {
            return Response<IEnumerable<CategoryWithArticlesDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<CategoryWithArticlesDto>>(_categoryRepository.GetArticlesWithCommentAndLikesPaginated(categoryId, (pageNumber - 1) * pageSize, pageSize)), 200);
        }

     

        public async Task<Response<IEnumerable<CategoryDto>>> GetWithArticlesCount()
        {
            return Response<IEnumerable<CategoryDto>>.Success( ObjectMapper.Mapper.Map<IEnumerable< CategoryDto>>(_categoryRepository.GetWithArticlesCount()), 200);
        }

        public async Task<Response<CategoryDto>> GetWithArticlesCountByIdAsync(int id)
        {
            return Response<CategoryDto>.Success(ObjectMapper.Mapper.Map<CategoryDto>( await _categoryRepository.GetWithArticlesCountByIdAsync(id)), 200);
        }
    }
}
