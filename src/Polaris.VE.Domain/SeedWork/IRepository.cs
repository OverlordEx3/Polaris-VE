namespace Polaris.VE.Domain.SeedWork;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; }

    Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
}