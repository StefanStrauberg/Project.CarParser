namespace Project.CarParser.Application.Contracts.Repositories;

public interface IPlaceCityRepository
  : IRepository<PlaceCity>,
    ICountRepository<PlaceCity>,
    IInsertRepository<PlaceCity>,
    IDeleteRepository<PlaceCity>,
    IReplaceRepository<PlaceCity>
{ }