using Infrastructure.Models;
using OfferArticleWebApi.Dto;

namespace RetailProcurementApp.Dto
{
    public class OfferIdDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public List<ArticleOfferItemDto> ArticleOfferItems { get; set; } = [];
    }
}
