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
    public class CommentService:GenericService<Comment, CommentDto>, ICommentService
    {
        private readonly ICommentRepository _repository;
        public CommentService(IUnitOfWork unitOfWork, ICommentRepository repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public async Task<Response<IEnumerable<CommentDto>>> GetCommentsByArticleId(int articleId, int pageNumber)
        {
            return Response<IEnumerable<CommentDto>>
                .Success(ObjectMapper.Mapper.
                Map<IEnumerable<CommentDto>>( await _repository.GetCommentsByArticleId(articleId, (pageNumber - 1) * 10, 10)), 200);
        }
    }
}
