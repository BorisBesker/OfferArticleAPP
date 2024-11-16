namespace Infrastructure.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public List<Article> Articles { get; } = [];

        public List<ArticleOfferItem> ArticleOfferItems { get; } = [];
    }
}
