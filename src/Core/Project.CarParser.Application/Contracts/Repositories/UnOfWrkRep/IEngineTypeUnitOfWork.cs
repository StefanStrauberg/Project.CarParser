namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a unit of work interface for managing IEngineType repository operations.
/// </summary>
public interface IEngineTypeUnitOfWork : IUnitOfWork
{
  IEngineTypeRepository EngineTypes { get; }
}
