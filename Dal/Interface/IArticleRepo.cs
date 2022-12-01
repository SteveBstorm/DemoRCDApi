using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface
{
    public interface IArticleRepo
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        void Create(Article article);
    }
}
