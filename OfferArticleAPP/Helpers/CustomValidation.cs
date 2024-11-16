using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace OfferArticleWebApi.Helpers
{
    public class NotNullOrEmptyCollectionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ICollection collection)
            {
                return collection.Count != 0;
            }

            var enumerable = value as IEnumerable;
            return enumerable != null && enumerable.GetEnumerator().MoveNext();
        }
    }
}
