namespace BookLibrary.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetFirst();
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Create(TEntity obj);
        Task<int> SaveChanges();
    }
}
