using Infrastructure.Data;
using Infrastructure.Models;

namespace Infrastructure.Repository
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(ArticleOfferContext context)
            : base(context) { }

        public bool Exists(int id)
        {
            return Context.Set<Offer>().Any(x => x.Id == id);
        }

        public IEnumerable<Offer> GetPaged(int currentPosition, int pageSize)
        {
            return Context.Set<Offer>().Skip(currentPosition).Take(pageSize).ToList();
        }
    }
}
