using System;
using TOEFL.Repositories;

namespace TOEFL.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }
    }
}
