using Infrastructure.Models;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public interface IOfferService
    {
        IEnumerable<Offer> GetOffers(int? page, int? pageSize);
        Offer? GetSpecificOffer(int id);
        ServiceResponse<Offer> CreateOffer(Offer item);
        ServiceResponse<Offer> UpdateOffer(int id, Offer updateOfferModel);
        public ServiceResponse<Offer> DeleteOffer(int id);
    }
}