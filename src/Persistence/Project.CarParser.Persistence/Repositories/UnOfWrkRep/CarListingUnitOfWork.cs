namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class CarListingUnitOfWork(IExistenceQueryRepository<CarListing> existenceQueryRepository,
                                    ICountRepository<CarListing> countRepository,
                                    IInsertRepository<CarListing> insertRepository,
                                    IDeleteRepository<CarListing> deleteRepository,
                                    IReplaceRepository<CarListing> replaceRepository,
                                    ApplicationDbContext applicationDbContext)
  : UnitOfWork(applicationDbContext), ICarListingUnitOfWork
{
  readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
  ICarListingRepository ICarListingUnitOfWork.CarListings
    => new CarListingRepository(existenceQueryRepository,
                                countRepository,
                                insertRepository,
                                deleteRepository,
                                replaceRepository,
                                _applicationDbContext);
}