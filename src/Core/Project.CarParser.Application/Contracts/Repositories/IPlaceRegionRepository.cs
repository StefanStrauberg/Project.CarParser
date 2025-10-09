namespace Project.CarParser.Application.Contracts.Repositories;

public interface IPlaceRegionRepository
  : IManyQueryRepository<PlaceRegion>,
    IOneQueryRepository<PlaceRegion>,
    IExistenceQueryRepository<PlaceRegion>,
    ICountRepository<PlaceRegion>,
    IInsertRepository<PlaceRegion>,
    IDeleteRepository<PlaceRegion>,
    IReplaceRepository<PlaceRegion>
{ }