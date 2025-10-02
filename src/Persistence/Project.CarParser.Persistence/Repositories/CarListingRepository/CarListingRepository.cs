namespace Project.CarParser.Persistence.Repositories.CarListingRepository;

public class CarListingRepository(IExistenceQueryRepository<CarListing> existenceQueryRepository,
                                  ICountRepository<CarListing> countRepository,
                                  IManyQueryRepository<CarListing> manyQueryRepository,
                                  IOneQueryRepository<CarListing> oneQueryRepository,
                                  IInsertRepository<CarListing> insertRepository,
                                  IDeleteRepository<CarListing> deleteRepository,
                                  IReplaceRepository<CarListing> replaceRepository) : ICarListingRepository
{
  async Task<CarListing> IOneQueryRepository<CarListing>.GetOneShortAsync(ISpecification<CarListing> specification,
                                                                          CancellationToken cancellationToken)
    => await oneQueryRepository.GetOneShortAsync(specification,
                                                 cancellationToken);

  async Task<bool> IExistenceQueryRepository<CarListing>.AnyByQueryAsync(ISpecification<CarListing> specification,
                                                                         CancellationToken cancellationToken)
    => await existenceQueryRepository.AnyByQueryAsync(specification,
                                                      cancellationToken);

  async Task<int> ICountRepository<CarListing>.GetCountAsync(ISpecification<CarListing> specification,
                                                             CancellationToken cancellationToken)
    => await countRepository.GetCountAsync(specification,
                                           cancellationToken);

  async Task<IEnumerable<CarListing>> IManyQueryRepository<CarListing>.GetManyShortAsync(ISpecification<CarListing> specification,
                                                                                         CancellationToken cancellationToken)
    => await manyQueryRepository.GetManyShortAsync(specification,
                                                   cancellationToken);

  void IInsertRepository<CarListing>.InsertOne(CarListing entity)
    => insertRepository.InsertOne(entity);

  void IDeleteRepository<CarListing>.DeleteOne(CarListing entity)
    => deleteRepository.DeleteOne(entity);

  void IReplaceRepository<CarListing>.ReplaceOne(CarListing entity)
    => replaceRepository.ReplaceOne(entity);
}
