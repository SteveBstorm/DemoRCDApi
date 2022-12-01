﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        void Create(Article article);
    }
}
