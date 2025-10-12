namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class PlaceRegionUnitOfWork(IExistenceQueryRepository<PlaceRegion> existenceQueryRepository,
                                     ICountRepository<PlaceRegion> countRepository,
                                     IManyQueryRepository<PlaceRegion> manyQueryRepository,
                                     IOneQueryRepository<PlaceRegion> oneQueryRepository,
                                     IInsertRepository<PlaceRegion> insertRepository,
                                     IDeleteRepository<PlaceRegion> deleteRepository,
                                     IReplaceRepository<PlaceRegion> replaceRepository,
                                     ApplicationDbContext applicationDbContext)
  : UnitOfWork(applicationDbContext), IPlaceRegionUnitOfWork
{
  IPlaceRegionRepository IPlaceRegionUnitOfWork.PlaceRegions
    => new PlaceRegionRepository(existenceQueryRepository,
                                 countRepository,
                                 manyQueryRepository,
                                 oneQueryRepository,
                                 insertRepository,
                                 deleteRepository,
                                 replaceRepository);
}