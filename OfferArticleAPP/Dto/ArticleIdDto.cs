namespace OfferArticleWebApi.Dto
{
    public class ArticleIdDto
    {
        public int Id { get; set; }

        public string ArticleName { get; set; }

        public string? ArticleDescription { get; set; }

        public decimal Price { get; set; }
    }
}
