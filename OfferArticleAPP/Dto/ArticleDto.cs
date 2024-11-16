using System.ComponentModel.DataAnnotations;

namespace OfferArticleWebApi.Dto
{
    public class ArticleDto
    {
        public string ArticleName { get; set; }

        public string ArticleDescription { get; set; }

        public decimal Price { get; set; }
    }
}
