namespace Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        IOfferRepository Offers { get; }

        IArticleRepository Articles { get; }

        int Save();
    }
}
