namespace Project.CarParser.Application.Contracts.Repositories;

public interface IPlaceCityRepository
  : IManyQueryRepository<PlaceCity>,
    IOneQueryRepository<PlaceCity>,
    IExistenceQueryRepository<PlaceCity>,
    ICountRepository<PlaceCity>,
    IInsertRepository<PlaceCity>,
    IDeleteRepository<PlaceCity>,
    IReplaceRepository<PlaceCity>
{ }