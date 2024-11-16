namespace Infrastructure.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string ArticleName { get; set; }

        public string ArticleDescription { get; set; }

        public decimal Price { get; set; }

        public List<Offer> Offers { get; } = [];

        public List<ArticleOfferItem> ArticleOfferItems { get; } = [];
    }
}
