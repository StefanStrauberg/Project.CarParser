namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a general unit of work interface for managing with entities.
/// </summary>
public interface IUnitOfWork
{
  ICarListingRepository CarListings { get; }
  /// <summary>
  /// Commits the current unit of work, persisting changes.
  /// </summary>
  void Complete();
  Task CompleteAsync(CancellationToken cancellationToken);
  void StartTransaction();
  Task StartTransactionAsync(CancellationToken cancellationToken);
}
