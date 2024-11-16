using Infrastructure.Models;

namespace Infrastructure.Repository
{
    public interface IOfferRepository : IRepository<Offer>
    {
        public bool Exists(int id);
        public IEnumerable<Offer> GetPaged(int currentPosition, int pageSize);
    }
}
