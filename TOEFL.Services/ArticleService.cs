using System;
using TOEFL.Repositories;
using TOEFL.Repository.Models;

namespace TOEFL.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleService(IRepository<Article> articleRepository)
        {
            this._articleRepository = articleRepository;
        }
    }
}
