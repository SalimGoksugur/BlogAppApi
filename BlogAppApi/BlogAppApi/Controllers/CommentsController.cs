using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
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
    public class CommentsController : CustomBaseController
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ActionResultInstance(await _commentService.GetAll());
        }

        [HttpGet("{articleId}/{pageNumber}")]
        public async Task<IActionResult> GetCommentsWithArticleId(int articleId, int pageNumber)
        {
            return ActionResultInstance(await _commentService.GetCommentsByArticleId(articleId, pageNumber));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ActionResultInstance(await _commentService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateDto commentDto)
        {
            var comment = ObjectMapper.Mapper.Map<CommentDto>(commentDto);
            return ActionResultInstance(await _commentService.AddAsync(comment));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return ActionResultInstance(await _commentService.Remove(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CommentUpdateDto commentDto)
        {
            return ActionResultInstance(await _commentService.Update(ObjectMapper.Mapper.Map<CommentDto>(commentDto)));
        }
    }
}
