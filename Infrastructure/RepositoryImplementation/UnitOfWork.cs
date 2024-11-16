using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.RepositoryImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArticleOfferContext _context;

        private IOfferRepository _offers;

        private IArticleRepository _articles;


        public UnitOfWork(ArticleOfferContext dataContext)
        {
            _context = dataContext;
        }

        public IOfferRepository Offers => _offers ??= new OfferRepository(_context);

        public IArticleRepository Articles  => _articles ??= new ArticleRepository(_context);


        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
