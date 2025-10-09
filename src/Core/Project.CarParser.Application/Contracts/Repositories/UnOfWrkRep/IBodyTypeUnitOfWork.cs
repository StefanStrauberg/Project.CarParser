namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a unit of work interface for managing IBodyType repository operations.
/// </summary>
public interface IBodyTypeUnitOfWork : IUnitOfWork
{
  IBodyTypeRepository BodyTypies { get; }
}
