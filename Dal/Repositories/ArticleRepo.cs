using Dal.Entities;
using Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class ArticleRepo : IArticleRepo
    {
        private IDbConnection _connection;

        public ArticleRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Create(Article article)
        {
            using(IDbCommand command = _connection.CreateCommand())
            {
                string sql = "INSERT INTO Article VALUES (@title, @price)";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("title", article.Title));
                command.Parameters.Add(new SqlParameter("price", article.Price));

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<Article> GetAll()
        {
            using (IDbCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Article";
                cmd.CommandText = sql;

                _connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Article
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Price = (int)reader["Price"]
                        };
                    }
                }
            }
        }

        public Article GetById(int id)
        {
            Article article = new Article();
            using (IDbCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Article WHERE Id = @id";
                cmd.Parameters.Add(new SqlParameter("id", id));
                cmd.CommandText = sql;

                _connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        article.Id = (int)reader["Id"];
                        article.Title = (string)reader["Title"];
                        article.Price = (int)reader["Price"];
                    }
                }
            }
            return article;
        }
    }
}

