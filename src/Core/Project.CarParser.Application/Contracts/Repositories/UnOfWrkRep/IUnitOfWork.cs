namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a general unit of work interface for managing with entities.
/// </summary>
public interface IUnitOfWork
{
  void Complete();
  Task CompleteAsync(CancellationToken cancellationToken);
  void StartTransaction();
  Task StartTransactionAsync(CancellationToken cancellationToken);
}