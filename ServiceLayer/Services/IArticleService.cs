using Infrastructure.Models;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public interface IArticleService
    {
        Article? GetSpecificArticle(int id);
        IEnumerable<Article> GetArticles();
        ServiceResponse<Article> CreateArticle(Article item);
        ServiceResponse<Article> UpdateArticle(int id, Article item);
        ServiceResponse<Article> DeleteArticle(int id);
    }
}