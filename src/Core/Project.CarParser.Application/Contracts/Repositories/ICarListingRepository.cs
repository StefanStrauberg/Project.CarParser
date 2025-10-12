namespace Project.CarParser.Application.Contracts.Repositories;

public interface ICarListingRepository
  : IRepository<CarListing>,
    IManyQueryRepository<CarListing>,
    ICountRepository<CarListing>,
    IInsertRepository<CarListing>,
    IDeleteRepository<CarListing>,
    IReplaceRepository<CarListing>
{ }
