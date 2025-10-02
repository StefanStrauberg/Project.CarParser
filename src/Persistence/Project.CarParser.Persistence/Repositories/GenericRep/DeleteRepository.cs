namespace Project.CarParser.Persistence.Repositories.GenericRep;

internal class DeleteRepository<T>(ApplicationDbContext context)
  : IDeleteRepository<T> where T : BaseEntity
{
  void IDeleteRepository<T>.DeleteOne(T entity)
    => context.Set<T>().Remove(entity);
}
