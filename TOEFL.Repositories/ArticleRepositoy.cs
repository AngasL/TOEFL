using System;
using System.Collections.Generic;
using System.Data.Entity;
using TOEFL.Repository.Models;

namespace TOEFL.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        public Article Add(Article article)
        {
            using (var ctx = new TOFELDBContext())
            {
                var result = ctx.Articles.Add(article);
                ctx.SaveChanges();

                return result;
            }
        }

        public IEnumerable<Article> AddRange(IEnumerable<Article> articles)
        {
            using (var ctx = new TOFELDBContext())
            {
                var result = ctx.Articles.AddRange(articles);
                ctx.SaveChanges();

                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new TOFELDBContext())
            {
                try
                {
                    var deleteCandidate = ctx.Articles.Find(id);
                    if (deleteCandidate != null)
                    {
                        ctx.Articles.Remove(deleteCandidate);
                    }

                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception exc)
                {
                    return false;
                }
            }
        }

        public Article Get(int id)
        {
            using (var ctx = new TOFELDBContext())
            {
                 return ctx.Articles.Find(id);
            }
        }

        public Article Update(Article item)
        {
            using (var ctx = new TOFELDBContext())
            {
                var updateCandidate = ctx.Articles.Find(item.ArticleId);
                if (updateCandidate != null)
                {
                    try
                    {
                        ctx.Articles.Attach(item);
                        ctx.Entry(item).State = EntityState.Modified;

                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                return updateCandidate;
            }
        }
    }
}
