namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class UnitOfWork(ApplicationDbContext applicationContext) : IUnitOfWork, IDisposable
{
  bool _disposed = false;
  IDbContextTransaction? _transaction;

  void IUnitOfWork.Complete()
  {
    applicationContext.SaveChanges();

    if (_transaction is not null)
      _transaction?.Commit();
  }

  async Task IUnitOfWork.CompleteAsync(CancellationToken cancellationToken)
  {
    await applicationContext.SaveChangesAsync(cancellationToken);

    if (_transaction is not null)
      await _transaction.CommitAsync(cancellationToken);
  }

  void IUnitOfWork.StartTransaction()
    => _transaction = applicationContext.Database.BeginTransaction();

  async Task IUnitOfWork.StartTransactionAsync(CancellationToken cancellationToken)
    => _transaction = await applicationContext.Database.BeginTransactionAsync(cancellationToken);

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
        applicationContext.Dispose();

      _disposed = true;
    }
  }

  ~UnitOfWork()
    => Dispose(false);
}
