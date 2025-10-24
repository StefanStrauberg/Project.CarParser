namespace Project.CarParser.Application.Contracts.Repositories;

public interface ICarListingRepository
  : IRepository<CarListing>,
    ICountRepository<CarListing>,
    IInsertRepository<CarListing>,
    IDeleteRepository<CarListing>,
    IReplaceRepository<CarListing>,
    IBulkInsertRepository<CarListing>
{ }
