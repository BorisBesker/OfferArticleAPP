namespace Infrastructure.Models
{
    public class ArticleOfferItem
    {
        public int ArticleId { get; set; }
        public int OfferId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public Offer Offer { get; set; } = null!;
        public Article Article { get; set; } = null!;
    }
}
