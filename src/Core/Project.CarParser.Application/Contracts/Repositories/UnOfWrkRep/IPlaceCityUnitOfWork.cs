namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a unit of work interface for managing IPlaceCity repository operations.
/// </summary>
public interface IPlaceCityUnitOfWork : IUnitOfWork
{
  IPlaceCityRepository PlaceCities { get; }
}
