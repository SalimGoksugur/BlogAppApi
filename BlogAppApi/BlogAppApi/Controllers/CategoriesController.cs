using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
using BlogAppApi.Service.Services;
using BlogAppApi.SharedLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ActionResultInstance(await _categoryService.GetWithArticlesCount());
        }
       
        [HttpGet("{categoryId}/{pageNumber}/{pageSize}")]
        public async Task <IActionResult> GetArticlesPaginated(int categoryId, int pageNumber, int pageSize)
        {
            return ActionResultInstance(await _categoryService.GetArticlesWithCommentAndLikesPaginated(categoryId, pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ActionResultInstance(await _categoryService.GetWithArticlesCountByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryDto)
        {
            return ActionResultInstance(await _categoryService.AddAsync(ObjectMapper.Mapper.Map<CategoryDto>(categoryDto)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return ActionResultInstance(await _categoryService.Remove(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryDto)
        {
            return ActionResultInstance(await _categoryService.Update(ObjectMapper.Mapper.Map<CategoryDto> (categoryDto)));
        }
    }
}
