using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = Dal.Entities;
using BL = BLL.Models;

namespace BLL.Tools
{
    public static class Mappers
    {
        public static DAL.Article ToDal(this BL.Article a)
        {
            return new DAL.Article
            {
                Id = a.Id,
                Title = a.Title,
                Price = a.Price
            };
        }
        public static BL.Article ToBLL(this DAL.Article a)
        {
            return new BL.Article
            {
                Id = a.Id,
                Title = a.Title,
                Price = a.Price
            };
        }
    }
}
