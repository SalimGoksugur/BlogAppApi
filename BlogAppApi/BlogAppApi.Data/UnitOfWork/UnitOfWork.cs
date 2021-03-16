using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private CategoryRepository _categoryRepository;
        private ArticleLikeRepository _articleLikeRepository;
        private ArticleRepository _articleRepository;
        private CommentLikeRepository _commentLikeRepository;
        private CommentRepository _commentRepository;
        private SavedArticleRepository _savedArticleRepository;
        private SecurityCodeRepository _securityCodeRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context ;
        }
        public CategoryRepository CategoryRepository => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context));
        public ArticleRepository ArticleRepository => _articleRepository ?? (_articleRepository = new ArticleRepository(_context));
        public ArticleLikeRepository ArticleLikeRepository => _articleLikeRepository ?? (_articleLikeRepository = new ArticleLikeRepository(_context));
        public CommentLikeRepository CommentLikeRepository => _commentLikeRepository ?? (_commentLikeRepository = new CommentLikeRepository(_context));
        public CommentRepository CommentRepository => _commentRepository ?? (_commentRepository = new CommentRepository(_context));
        public SavedArticleRepository SavedArticleRepository => _savedArticleRepository ?? (_savedArticleRepository = new SavedArticleRepository(_context));
        public SecurityCodeRepository SecurityCodeRepository => _securityCodeRepository ?? (_securityCodeRepository = new SecurityCodeRepository(_context));
       
        public bool Save()
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                //TODO:Logging
                return false;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
