using System.ComponentModel.DataAnnotations;

namespace OfferArticleAppBlazor.Models
{
    public class UpdateOrCreateArticleOfferItemDto
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal Quantity { get; set; }
    }
}
