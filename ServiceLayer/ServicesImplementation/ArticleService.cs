using Infrastructure.Models;
using Infrastructure.Repository;
using ServiceLayer.Models;
using ServiceLayer.Services;

namespace ServiceLayer.ServicesImplementation
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _database;

        public ArticleService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _database.Articles.GetAll();
        }

        public Article? GetSpecificArticle(int id)
        {
            if (!_database.Articles.Exists(id))
            {
                return null;
            }
            return _database.Articles.Get(id);
        }

        public ServiceResponse<Article> CreateArticle(Article item)
        {
            if (_database.Articles.ExistsWithSameName(item.ArticleName))
            {
                return new ServiceResponse<Article> { Success = false, ExistSameName = true };
            }

            _database.Articles.Add(item);

            _database.Save();

            return new ServiceResponse<Article> { Success = true, ExistSameName = false, Entity = item };
        }

        public ServiceResponse<Article> UpdateArticle(int id, Article item)
        {
            if (!_database.Articles.Exists(id))
            {
                return new ServiceResponse<Article> { Success = false, RecordExists = false };
            }

            item.Id = id;

            _database.Articles.Update(item);

            _database.Save();

            return new ServiceResponse<Article> { Success = true, RecordExists = true, Entity = item };
        }

        public ServiceResponse<Article> DeleteArticle(int id)
        {
            if (!_database.Articles.Exists(id))
            {
                return new ServiceResponse<Article> { Success = false, RecordExists = false };
            }

            var article = new Article
            {
                Id = id
            };

            _database.Articles.Remove(article);

            _database.Save();

            return new ServiceResponse<Article> { Success = true, RecordExists = true, Entity = article };
        }
    }
}
