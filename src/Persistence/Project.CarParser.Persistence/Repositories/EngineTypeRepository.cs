namespace Project.CarParser.Persistence.Repositories;

public class EngineTypeRepository(IExistenceQueryRepository<EngineType> existenceQueryRepository,
                                  ICountRepository<EngineType> countRepository,
                                  IManyQueryRepository<EngineType> manyQueryRepository,
                                  IOneQueryRepository<EngineType> oneQueryRepository,
                                  IInsertRepository<EngineType> insertRepository,
                                  IDeleteRepository<EngineType> deleteRepository,
                                  IReplaceRepository<EngineType> replaceRepository) : IEngineTypeRepository
{
  async Task<EngineType> IOneQueryRepository<EngineType>.GetOneShortAsync(ISpecification<EngineType> specification,
                                                                          CancellationToken cancellationToken)
    => await oneQueryRepository.GetOneShortAsync(specification, cancellationToken);

  async Task<bool> IExistenceQueryRepository<EngineType>.AnyByQueryAsync(ISpecification<EngineType> specification,
                                                                         CancellationToken cancellationToken)
    => await existenceQueryRepository.AnyByQueryAsync(specification, cancellationToken);

  async Task<int> ICountRepository<EngineType>.GetCountAsync(ISpecification<EngineType> specification,
                                                             CancellationToken cancellationToken)
    => await countRepository.GetCountAsync(specification, cancellationToken);

  async Task<IEnumerable<EngineType>> IManyQueryRepository<EngineType>.GetManyShortAsync(ISpecification<EngineType> specification,
                                                                                         CancellationToken cancellationToken)
    => await manyQueryRepository.GetManyShortAsync(specification, cancellationToken);

  void IInsertRepository<EngineType>.InsertOne(EngineType entity)
    => insertRepository.InsertOne(entity);

  void IDeleteRepository<EngineType>.DeleteOne(EngineType entity)
    => deleteRepository.DeleteOne(entity);

  void IReplaceRepository<EngineType>.ReplaceOne(EngineType entity)
    => replaceRepository.ReplaceOne(entity);
}
