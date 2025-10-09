namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a unit of work interface for managing ICarListing repository operations.
/// </summary>
public interface ICarListingUnitOfWork : IUnitOfWork
{
  ICarListingRepository CarListings { get; }
}
