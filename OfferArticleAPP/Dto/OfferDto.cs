using OfferArticleWebApi.Dto;
using OfferArticleWebApi.Helpers;

namespace RetailProcurementApp.Dto
{
    public class OfferDto
    {
        [NotNullOrEmptyCollection]
        public List<UpdateOrCreateArticleOfferItemDto> ArticleOfferItems { get; set;  } = [];
    }
}
