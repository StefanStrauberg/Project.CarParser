namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class UnitOfWork(ApplicationDbContext applicationDbContext) : IUnitOfWork, IDisposable
{
  bool _disposed = false;
  IDbContextTransaction? _transaction;

  void IUnitOfWork.Complete()
  {
    applicationDbContext.SaveChanges();

    if (_transaction is not null)
      _transaction?.Commit();
  }

  async Task IUnitOfWork.CompleteAsync(CancellationToken cancellationToken)
  {
    await applicationDbContext.SaveChangesAsync(cancellationToken);

    if (_transaction is not null)
      await _transaction.CommitAsync(cancellationToken);
  }

  void IUnitOfWork.StartTransaction()
    => _transaction = applicationDbContext.Database.BeginTransaction();

  async Task IUnitOfWork.StartTransactionAsync(CancellationToken cancellationToken)
    => _transaction = await applicationDbContext.Database.BeginTransactionAsync(cancellationToken);

  void IDisposable.Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!_disposed)
    {
      if (disposing)
        applicationDbContext.Dispose();

      _disposed = true;
    }
  }

  ~UnitOfWork()
    => Dispose(false);
}
