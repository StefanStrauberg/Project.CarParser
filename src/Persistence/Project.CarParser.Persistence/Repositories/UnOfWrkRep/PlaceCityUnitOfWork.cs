namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class PlaceCityUnitOfWork(IExistenceQueryRepository<PlaceCity> existenceQueryRepository,
                                   ICountRepository<PlaceCity> countRepository,
                                   IManyQueryRepository<PlaceCity> manyQueryRepository,
                                   IOneQueryRepository<PlaceCity> oneQueryRepository,
                                   IInsertRepository<PlaceCity> insertRepository,
                                   IDeleteRepository<PlaceCity> deleteRepository,
                                   IReplaceRepository<PlaceCity> replaceRepository,
                                   ApplicationDbContext applicationDbContext)
  : UnitOfWork(applicationDbContext), IPlaceCityUnitOfWork
{
  IPlaceCityRepository IPlaceCityUnitOfWork.PlaceCities
    => new PlaceCityRepository(existenceQueryRepository,
                               countRepository,
                               manyQueryRepository,
                               oneQueryRepository,
                               insertRepository,
                               deleteRepository,
                               replaceRepository);
}
