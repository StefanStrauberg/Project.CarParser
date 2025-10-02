namespace Project.CarParser.Application.Contracts.Repositories.CarListingRepository;

public interface ICarListingRepository
  : IManyQueryRepository<CarListing>,
    IOneQueryRepository<CarListing>,
    IExistenceQueryRepository<CarListing>,
    ICountRepository<CarListing>,
    IInsertRepository<CarListing>,
    IDeleteRepository<CarListing>,
    IReplaceRepository<CarListing>
{ }
