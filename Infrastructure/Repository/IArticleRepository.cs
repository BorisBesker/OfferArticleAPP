using Infrastructure.Models;

namespace Infrastructure.Repository
{
    public interface IArticleRepository : IRepository<Article>
    {
        public bool Exists(int id);
        public bool ExistsWithSameName(string name);
    }
}
