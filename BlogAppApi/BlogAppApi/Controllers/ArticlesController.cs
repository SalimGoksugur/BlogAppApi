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
    public class ArticlesController : CustomBaseController
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            await _articleService.UpdateViewCount(id);
            return ActionResultInstance(await _articleService.GetByIdAsync(id));
        }

        [HttpGet("{categoryId}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetPaginatedByCategoryId(int categoryId, int pageNumber, int pageSize)
        {
            return ActionResultInstance(await _articleService.GetPaginatedByCategoryId(categoryId, pageNumber, pageSize, 1));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateDto articleDto)
        {
            return ActionResultInstance(await _articleService.AddAsync(ObjectMapper.Mapper.Map<ArticleDto>( articleDto)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return ActionResultInstance(await _articleService.Remove(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ArticleUpdateDto articleDto)
        {
            return ActionResultInstance(await _articleService.Update(articleDto));
        }
    }
}
