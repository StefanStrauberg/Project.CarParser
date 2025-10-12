namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class EngineTypeUnitOfWork(IExistenceQueryRepository<EngineType> existenceQueryRepository,
                                  ICountRepository<EngineType> countRepository,
                                  IManyQueryRepository<EngineType> manyQueryRepository,
                                  IOneQueryRepository<EngineType> oneQueryRepository,
                                  IInsertRepository<EngineType> insertRepository,
                                  IDeleteRepository<EngineType> deleteRepository,
                                  IReplaceRepository<EngineType> replaceRepository,
                                  ApplicationDbContext applicationDbContext)
  : UnitOfWork(applicationDbContext), IEngineTypeUnitOfWork
{
  IEngineTypeRepository IEngineTypeUnitOfWork.EngineTypies
    => new EngineTypeRepository(existenceQueryRepository,
                                countRepository,
                                manyQueryRepository,
                                oneQueryRepository,
                                insertRepository,
                                deleteRepository,
                                replaceRepository);
}
