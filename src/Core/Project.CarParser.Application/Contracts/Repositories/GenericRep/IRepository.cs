
namespace Project.CarParser.Application.Contracts.Repositories.GenericRep;

public interface IRepository<TEntity> : IExistenceQueryRepository<TEntity>, IOneQueryRepository<TEntity>
  where TEntity : BaseEntity
{ }
