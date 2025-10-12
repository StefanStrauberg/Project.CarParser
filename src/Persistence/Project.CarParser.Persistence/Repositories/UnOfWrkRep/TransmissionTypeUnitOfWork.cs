namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class TransmissionTypeUnitOfWork(IExistenceQueryRepository<TransmissionType> existenceQueryRepository,
                                          ICountRepository<TransmissionType> countRepository,
                                          IManyQueryRepository<TransmissionType> manyQueryRepository,
                                          IOneQueryRepository<TransmissionType> oneQueryRepository,
                                          IInsertRepository<TransmissionType> insertRepository,
                                          IDeleteRepository<TransmissionType> deleteRepository,
                                          IReplaceRepository<TransmissionType> replaceRepository,
                                          ApplicationDbContext applicationDbContext)
  : UnitOfWork(applicationDbContext), ITransmissionTypeUnitOfWork
{
  ITransmissionTypeRepository ITransmissionTypeUnitOfWork.TransmissionTypies
    => new TransmissionTypeRepository(existenceQueryRepository,
                                      countRepository,
                                      manyQueryRepository,
                                      oneQueryRepository,
                                      insertRepository,
                                      deleteRepository,
                                      replaceRepository);
}