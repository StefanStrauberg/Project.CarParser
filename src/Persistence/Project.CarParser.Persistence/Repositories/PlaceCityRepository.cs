namespace Project.CarParser.Persistence.Repositories;

public class PlaceCityRepository(IExistenceQueryRepository<PlaceCity> existenceQueryRepository,
                                 ICountRepository<PlaceCity> countRepository,
                                 IManyQueryRepository<PlaceCity> manyQueryRepository,
                                 IOneQueryRepository<PlaceCity> oneQueryRepository,
                                 IInsertRepository<PlaceCity> insertRepository,
                                 IDeleteRepository<PlaceCity> deleteRepository,
                                 IReplaceRepository<PlaceCity> replaceRepository) : IPlaceCityRepository
{
  async Task<PlaceCity> IOneQueryRepository<PlaceCity>.GetOneShortAsync(ISpecification<PlaceCity> specification,
                                                                        CancellationToken cancellationToken)
    => await oneQueryRepository.GetOneShortAsync(specification, cancellationToken);

  async Task<bool> IExistenceQueryRepository<PlaceCity>.AnyByQueryAsync(ISpecification<PlaceCity> specification,
                                                                        CancellationToken cancellationToken)
    => await existenceQueryRepository.AnyByQueryAsync(specification, cancellationToken);

  async Task<int> ICountRepository<PlaceCity>.GetCountAsync(ISpecification<PlaceCity> specification,
                                                             CancellationToken cancellationToken)
    => await countRepository.GetCountAsync(specification, cancellationToken);

  async Task<IEnumerable<PlaceCity>> IManyQueryRepository<PlaceCity>.GetManyShortAsync(ISpecification<PlaceCity> specification,
                                                                                       CancellationToken cancellationToken)
    => await manyQueryRepository.GetManyShortAsync(specification, cancellationToken);

  void IInsertRepository<PlaceCity>.InsertOne(PlaceCity entity)
    => insertRepository.InsertOne(entity);

  void IDeleteRepository<PlaceCity>.DeleteOne(PlaceCity entity)
    => deleteRepository.DeleteOne(entity);

  void IReplaceRepository<PlaceCity>.ReplaceOne(PlaceCity entity)
    => replaceRepository.ReplaceOne(entity);
}
