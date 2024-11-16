namespace Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(params object?[] id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
