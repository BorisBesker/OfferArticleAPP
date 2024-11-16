using Infrastructure.Data;
using Infrastructure.Models;

namespace Infrastructure.Repository
{
    public class ArticleRepository : Repository<Article> , IArticleRepository
    {
        public ArticleRepository(ArticleOfferContext context)
            : base(context) { }

        public bool Exists(int id)
        {
            return Context.Set<Article>().Any(x => x.Id == id);
        }

        public bool ExistsWithSameName(string name)
        {
            return Context.Set<Article>().Any(x => x.ArticleName.Trim().ToUpper() == name.Trim().ToUpper());
        }
    }
}
