namespace Project.CarParser.Persistence.Repositories;

public class BodyTypeRepository(IExistenceQueryRepository<BodyType> existenceQueryRepository,
                                ICountRepository<BodyType> countRepository,
                                IManyQueryRepository<BodyType> manyQueryRepository,
                                IOneQueryRepository<BodyType> oneQueryRepository,
                                IInsertRepository<BodyType> insertRepository,
                                IDeleteRepository<BodyType> deleteRepository,
                                IReplaceRepository<BodyType> replaceRepository) : IBodyTypeRepository
{
  async Task<BodyType> IOneQueryRepository<BodyType>.GetOneShortAsync(ISpecification<BodyType> specification,
                                                                      CancellationToken cancellationToken)
    => await oneQueryRepository.GetOneShortAsync(specification, cancellationToken);

  async Task<bool> IExistenceQueryRepository<BodyType>.AnyByQueryAsync(ISpecification<BodyType> specification,
                                                                       CancellationToken cancellationToken)
    => await existenceQueryRepository.AnyByQueryAsync(specification, cancellationToken);

  async Task<int> ICountRepository<BodyType>.GetCountAsync(ISpecification<BodyType> specification,
                                                           CancellationToken cancellationToken)
    => await countRepository.GetCountAsync(specification, cancellationToken);

  async Task<IEnumerable<BodyType>> IManyQueryRepository<BodyType>.GetManyShortAsync(ISpecification<BodyType> specification,
                                                                                     CancellationToken cancellationToken)
    => await manyQueryRepository.GetManyShortAsync(specification, cancellationToken);

  void IInsertRepository<BodyType>.InsertOne(BodyType entity)
    => insertRepository.InsertOne(entity);

  void IDeleteRepository<BodyType>.DeleteOne(BodyType entity)
    => deleteRepository.DeleteOne(entity);

  void IReplaceRepository<BodyType>.ReplaceOne(BodyType entity)
    => replaceRepository.ReplaceOne(entity);
}
