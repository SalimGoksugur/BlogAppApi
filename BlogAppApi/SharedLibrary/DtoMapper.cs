using AutoMapper;
using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.SharedLibrary
{
    class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Article, ArticleDto>().
                ForMember(dto=>dto.LikeCount, opt=>opt.MapFrom(art=>art.Likes.Count)).
                ForMember(dto=>dto.CommentCount, opt=>opt.MapFrom(art=>art.Comments.Count)). ReverseMap();
                
            CreateMap<ArticleDto, ArticleCreateDto>().ReverseMap();
            CreateMap<ArticleDto, ArticleUpdateDto>().ReverseMap();
            CreateMap< CategoryWithArticlesDto, Category>().ReverseMap().
                ForMember(cat=>cat.Articles, opt=>opt.MapFrom(src=>src.Articles));
            CreateMap<ArticleLike, ArticleLikeDto>().ReverseMap();

            CreateMap<Category, CategoryDto>()
                .ForMember(dto=>dto.ArticlesCount, opt=>opt.MapFrom(cat=>cat.Articles.Count)).ReverseMap();
            CreateMap<CategoryCreateDto, CategoryDto>().ReverseMap();
            CreateMap<CategoryUpdateDto, CategoryDto>().ReverseMap();
            
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<CommentDto, CommentCreateDto>().ReverseMap();
            CreateMap<CommentUpdateDto, CommentDto>().ReverseMap();
            CreateMap<CommentLike, CommentLikeDto>().ReverseMap();
            CreateMap<SavedArticle, SavedArticleDto>().ReverseMap();
            CreateMap< SavedArticle, SavedArticlesDto >().
                ForMember(dto=>dto.ArticleDto, opt=>opt.MapFrom(src=>src.Article)).
                ForMember(dto=>dto.SaveDate, opt=>opt.MapFrom(src=>src.SaveDate)).ReverseMap();
            CreateMap<UserDto, AppUser>().ReverseMap();

            CreateMap<AppRole, RoleDto>().ReverseMap();
            CreateMap<AppRole, RoleCreateDto>().ReverseMap();
        }
    }
}