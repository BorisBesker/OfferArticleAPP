using System.ComponentModel.DataAnnotations;

namespace OfferArticleWebApi.Helpers
{
    public class OfferQueryParams
    {
        [Range(1, int.MaxValue)]
        public int? Page { get; set; }

        [Range(1, Int32.MaxValue)]
        public int? PageSize { get; set; }
    }
}
