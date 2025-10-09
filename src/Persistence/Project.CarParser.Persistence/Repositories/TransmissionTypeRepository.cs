namespace Project.CarParser.Persistence.Repositories;

public class TransmissionTypeRepository(IExistenceQueryRepository<TransmissionType> existenceQueryRepository,
                                        ICountRepository<TransmissionType> countRepository,
                                        IManyQueryRepository<TransmissionType> manyQueryRepository,
                                        IOneQueryRepository<TransmissionType> oneQueryRepository,
                                        IInsertRepository<TransmissionType> insertRepository,
                                        IDeleteRepository<TransmissionType> deleteRepository,
                                        IReplaceRepository<TransmissionType> replaceRepository) : ITransmissionTypeRepository
{
  async Task<TransmissionType> IOneQueryRepository<TransmissionType>.GetOneShortAsync(ISpecification<TransmissionType> specification,
                                                                                      CancellationToken cancellationToken)
    => await oneQueryRepository.GetOneShortAsync(specification, cancellationToken);

  async Task<bool> IExistenceQueryRepository<TransmissionType>.AnyByQueryAsync(ISpecification<TransmissionType> specification,
                                                                               CancellationToken cancellationToken)
    => await existenceQueryRepository.AnyByQueryAsync(specification, cancellationToken);

  async Task<int> ICountRepository<TransmissionType>.GetCountAsync(ISpecification<TransmissionType> specification,
                                                                   CancellationToken cancellationToken)
    => await countRepository.GetCountAsync(specification, cancellationToken);

  async Task<IEnumerable<TransmissionType>> IManyQueryRepository<TransmissionType>.GetManyShortAsync(ISpecification<TransmissionType> specification,
                                                                                                     CancellationToken cancellationToken)
    => await manyQueryRepository.GetManyShortAsync(specification, cancellationToken);

  void IInsertRepository<TransmissionType>.InsertOne(TransmissionType entity)
    => insertRepository.InsertOne(entity);

  void IDeleteRepository<TransmissionType>.DeleteOne(TransmissionType entity)
    => deleteRepository.DeleteOne(entity);

  void IReplaceRepository<TransmissionType>.ReplaceOne(TransmissionType entity)
    => replaceRepository.ReplaceOne(entity);
}
