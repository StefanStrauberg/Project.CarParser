namespace Project.CarParser.Persistence.Repositories;

public class PlaceRegionRepository(IExistenceQueryRepository<PlaceRegion> existenceQueryRepository,
                                   ICountRepository<PlaceRegion> countRepository,
                                   IManyQueryRepository<PlaceRegion> manyQueryRepository,
                                   IOneQueryRepository<PlaceRegion> oneQueryRepository,
                                   IInsertRepository<PlaceRegion> insertRepository,
                                   IDeleteRepository<PlaceRegion> deleteRepository,
                                   IReplaceRepository<PlaceRegion> replaceRepository) : IPlaceRegionRepository
{
  async Task<PlaceRegion> IOneQueryRepository<PlaceRegion>.GetOneShortAsync(ISpecification<PlaceRegion> specification,
                                                                            CancellationToken cancellationToken)
    => await oneQueryRepository.GetOneShortAsync(specification, cancellationToken);

  async Task<bool> IExistenceQueryRepository<PlaceRegion>.AnyByQueryAsync(ISpecification<PlaceRegion> specification,
                                                                          CancellationToken cancellationToken)
    => await existenceQueryRepository.AnyByQueryAsync(specification, cancellationToken);

  async Task<int> ICountRepository<PlaceRegion>.GetCountAsync(ISpecification<PlaceRegion> specification,
                                                              CancellationToken cancellationToken)
    => await countRepository.GetCountAsync(specification, cancellationToken);

  async Task<IEnumerable<PlaceRegion>> IManyQueryRepository<PlaceRegion>.GetManyShortAsync(ISpecification<PlaceRegion> specification,
                                                                                           CancellationToken cancellationToken)
    => await manyQueryRepository.GetManyShortAsync(specification, cancellationToken);

  void IInsertRepository<PlaceRegion>.InsertOne(PlaceRegion entity)
    => insertRepository.InsertOne(entity);

  void IDeleteRepository<PlaceRegion>.DeleteOne(PlaceRegion entity)
    => deleteRepository.DeleteOne(entity);

  void IReplaceRepository<PlaceRegion>.ReplaceOne(PlaceRegion entity)
    => replaceRepository.ReplaceOne(entity);
}
