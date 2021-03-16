using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
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
    public class LikesController : CustomBaseController
    {
        private readonly IGenericService<ArticleLike, ArticleLikeDto> _likeService;
        public LikesController(IGenericService<ArticleLike, ArticleLikeDto> likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike(ArticleLikeDto like)
        {
            return ActionResultInstance(await _likeService.AddAsync(like));
        }
        [HttpDelete("{articleId}")]
        public async Task<IActionResult> RemoveLike(int articleId)
        {
            return ActionResultInstance(await _likeService.Remove(articleId));
        }
    }
}
