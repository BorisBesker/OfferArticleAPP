using System.ComponentModel.DataAnnotations;

namespace OfferArticleAppBlazor.Models
{
    public class ArticleCreateDto
    {
        [Required]
        public string ArticleName { get; set; }

        [Required]
        public string ArticleDescription { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
