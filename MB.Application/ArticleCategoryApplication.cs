using System;
using System.Collections.Generic;
using System.Globalization;
using MB.Application.Contracts;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var ArticleCategories = _articleCategoryRepository.GetAll();
            var Result = new List<ArticleCategoryViewModel>();
            foreach (var ArticleCategory in ArticleCategories)
            {
                Result.Add(new ArticleCategoryViewModel
                {
                    Id=ArticleCategory.Id,
                    Title = ArticleCategory.Title,
                    IsDeleted = ArticleCategory.IsDeleted,
                    CreationDate = ArticleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }
            return Result;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title);
            _articleCategoryRepository.Create(articleCategory);
        }
    }
}
