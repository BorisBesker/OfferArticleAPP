using Infrastructure.Models;
using Infrastructure.Repository;
using ServiceLayer.Models;
using ServiceLayer.Services;

namespace ServiceLayer.ServicesImplementation
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _database;

        public OfferService(IUnitOfWork database)
        {
            _database = database;
        }


        public IEnumerable<Offer> GetOffers(int? page, int? pageSize)
        {
            if (!page.HasValue || !pageSize.HasValue) 
                return _database.Offers.GetAll();
            
            var position = (page - 1) * pageSize;

            return _database.Offers.GetPaged(position.Value, pageSize.Value);

        }

        public Offer? GetSpecificOffer(int id)
        {
            if (!_database.Offers.Exists(id))
            {
                return null;
            }
            return _database.Offers.Get(id);
        }

        public ServiceResponse<Offer> CreateOffer(Offer offer)
        {

            foreach (var articleOfferItem in offer.ArticleOfferItems)
            {
                var existingArticle = _database.Articles.Get(articleOfferItem.ArticleId);

                if (existingArticle == null)
                {
                    return new ServiceResponse<Offer> { Success = false, RecordExists = false };
                }

            }

            offer.Date = DateTime.Now;

            _database.Offers.Add(offer);

            _database.Save();

            return new ServiceResponse<Offer> { Success = true, Entity = offer , RecordExists = true};
        }

        public ServiceResponse<Offer> UpdateOffer(int id, Offer updateOfferModel)
        {
            var offer = _database.Offers.Get(id);

            if (offer == null)
            {
                return new ServiceResponse<Offer> { Success = false, RecordExists = false };
            }

            foreach (var existingArticle in offer.ArticleOfferItems.ToList())
            {
                if (!updateOfferModel.ArticleOfferItems.Any(c => c.ArticleId == existingArticle.ArticleId))
                {
                    var articleOfferToRemove =
                        offer.ArticleOfferItems.Single(x => x.ArticleId == existingArticle.ArticleId);


                    offer.ArticleOfferItems.Remove(articleOfferToRemove);
                }
            }

            foreach (var articleOfferItem in updateOfferModel.ArticleOfferItems)
            {
                var articleOffer = offer.ArticleOfferItems
                    .SingleOrDefault(c => c.ArticleId == articleOfferItem.ArticleId);

                if (articleOffer != null)
                {
                    articleOffer.Quantity = articleOfferItem.Quantity;
                    articleOffer.UnitPrice = articleOfferItem.UnitPrice;
                }
                else
                {
                    offer.ArticleOfferItems.Add(new ArticleOfferItem { UnitPrice = articleOfferItem.UnitPrice, Quantity = articleOfferItem.Quantity, ArticleId = articleOfferItem.ArticleId, OfferId = id });
                }
            }

            _database.Save();

            return new ServiceResponse<Offer> { Success = true, RecordExists = true, Entity = updateOfferModel };
        }

        public ServiceResponse<Offer> DeleteOffer(int id)
        {
            if (!_database.Offers.Exists(id))
            {
                return new ServiceResponse<Offer> { Success = false, RecordExists = false };
            }

            var offer = new Offer()
            {
                Id = id
            };

            _database.Offers.Remove(offer);

            _database.Save();

            return new ServiceResponse<Offer> { Success = true, RecordExists = true, Entity = offer };
        }
    }
}
