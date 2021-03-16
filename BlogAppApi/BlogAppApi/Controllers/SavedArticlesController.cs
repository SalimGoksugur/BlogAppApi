using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
using BlogAppApi.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveArticlesController : CustomBaseController
    {
        private readonly ISavedArticleService _savedArticleService;
        public SaveArticlesController(ISavedArticleService service)
        {
            _savedArticleService = service;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetSavedArticles(int pageNumber, int pageSize)
        {
           return ActionResultInstance(await _savedArticleService.GetSavedArticles(1, pageNumber, pageSize));
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> SaveArticle(SavedArticleCreateDto dto)
        {
            int userId=Convert.ToInt32( User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var article =await _savedArticleService.GetSavedArticle(userId, dto.articleId);
            if (article != null)
                return ActionResultInstance(await _savedArticleService.RemoveArticle(dto.articleId));

           return ActionResultInstance(await _savedArticleService.SaveArticle(userId, dto.articleId));
        }
        [HttpDelete("{articleId}")]
        public async Task<IActionResult> RemoveSavedArticle(int articleId)
        {
            return ActionResultInstance (await _savedArticleService.RemoveArticle(articleId));
        }

       
    }
}
