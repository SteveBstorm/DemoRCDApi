using BLL.Interface;
using BLL.Models;
using BLL.Tools;
using Dal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepo repo;

        public ArticleService(IArticleRepo repo)
        {
            this.repo = repo;
        }

        public void Create(Article article)
        {
            repo.Create(article.ToDal());
        }

        public IEnumerable<Article> GetAll()
        {
            return repo.GetAll().Select(x => x.ToBLL());
        }

        public Article GetById(int id)
        {
            return repo.GetById(id).ToBLL();
        }
    }
}
