namespace OfferArticleAppBlazor.Models
{
    public class OfferIdDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public List<ArticleOfferItemDto> ArticleOfferItems { get; set; } = [];
    }
}
