namespace Project.CarParser.Application.Contracts.Repositories;

public interface IPlaceRegionRepository
  : IRepository<PlaceRegion>,
    IManyQueryRepository<PlaceRegion>,
    ICountRepository<PlaceRegion>,
    IInsertRepository<PlaceRegion>,
    IDeleteRepository<PlaceRegion>,
    IReplaceRepository<PlaceRegion>
{ }