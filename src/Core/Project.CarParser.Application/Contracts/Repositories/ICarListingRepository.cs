namespace Project.CarParser.Application.Contracts.Repositories;

public interface ICarListingRepository
  : IManyQueryRepository<CarListing>,
    IOneQueryRepository<CarListing>,
    IExistenceQueryRepository<CarListing>,
    ICountRepository<CarListing>,
    IInsertRepository<CarListing>,
    IDeleteRepository<CarListing>,
    IReplaceRepository<CarListing>
{ }
