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
                    var articleToRemove = _database.Articles.Get(existingArticle.ArticleId);

                    var articleOfferToRemove =
                        offer.ArticleOfferItems.SingleOrDefault(x => x.ArticleId == existingArticle.ArticleId);


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
                    var articleToAdd = _database.Articles.Get(articleOfferItem.ArticleId);
                    offer.ArticleOfferItems.Add(new ArticleOfferItem { Offer = offer, Article = articleToAdd });
                }
            }

            _database.Save();

            return new ServiceResponse<Offer> { Success = true, RecordExists = true, Entity = updateOfferModel };
        }

        //public ServiceResponse<Suplier> DeleteSuplier(int id)
        //{
        //    if (!_database.Supliers.Exists(id))
        //    {
        //        return new ServiceResponse<Suplier> { Success = false, RecordExists = false };
        //    }

        //    var suplier = new Suplier
        //    {
        //        Id = id
        //    };

        //    _database.Supliers.Remove(suplier);

        //    _database.Save();

        //    return new ServiceResponse<Suplier> { Success = true, RecordExists = true, Entity = suplier };
        //}
    }
}
