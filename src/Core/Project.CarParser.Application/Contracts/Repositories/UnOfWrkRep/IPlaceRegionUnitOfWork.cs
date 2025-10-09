namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a unit of work interface for managing IPlaceRegion repository operations.
/// </summary>
public interface IPlaceRegionUnitOfWork : IUnitOfWork
{
  IPlaceRegionRepository PlaceRegions { get; }
}
