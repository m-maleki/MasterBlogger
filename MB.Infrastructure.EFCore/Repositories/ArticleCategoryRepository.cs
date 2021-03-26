using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore.Repositories;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;


        public ArticleCategoryRepository(MasterBloggerContext context) 
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x=> x.Id).ToList();
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            _context.SaveChanges();
        }
    }
}
