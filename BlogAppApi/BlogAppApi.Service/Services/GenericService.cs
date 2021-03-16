using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.IRepositories;
using BlogAppApi.Core.IServices;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;
        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<Response<NoDataDto>> AddAsync(TDto entity)
        {
            
          await _repository.AddAsync(ObjectMapper.Mapper.Map<TEntity>(entity));
            _unitOfWork.Save();
            return Response<NoDataDto>.Success(201);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAll()
        {
            var entities= _repository.GetAllAsync();

             var dtos=ObjectMapper.Mapper.Map<IEnumerable< TDto>>(entities);
            return Response<IEnumerable<TDto>>.Success(dtos,200);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return Response<TDto>.Fail("Kayıt bulunamadı", 404);
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(entity), 200);
        }

    

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            await _repository.Remove(await _repository.GetByIdAsync(id));
            _unitOfWork.Save();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<NoDataDto>> Update(TDto entity)
        {
            _repository.Update(ObjectMapper.Mapper.Map<TEntity>(entity));
            _unitOfWork.Save();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _repository.Where(predicate);
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map <IEnumerable<TDto>>(entities), 200);
        }
    }
}
