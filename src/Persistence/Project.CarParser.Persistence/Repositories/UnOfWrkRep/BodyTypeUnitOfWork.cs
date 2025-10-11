namespace Project.CarParser.Persistence.Repositories.UnOfWrkRep;

internal class BodyTypeUnitOfWork(IExistenceQueryRepository<BodyType> existenceQueryRepository,
                                  ICountRepository<BodyType> countRepository,
                                  IManyQueryRepository<BodyType> manyQueryRepository,
                                  IOneQueryRepository<BodyType> oneQueryRepository,
                                  IInsertRepository<BodyType> insertRepository,
                                  IDeleteRepository<BodyType> deleteRepository,
                                  IReplaceRepository<BodyType> replaceRepository,
                                  ApplicationDbContext applicationDbContext)
  : UnitOfWork(applicationDbContext), IBodyTypeUnitOfWork
{
  IBodyTypeRepository IBodyTypeUnitOfWork.BodyTypies
    => new BodyTypeRepository(existenceQueryRepository,
                              countRepository,
                              manyQueryRepository,
                              oneQueryRepository,
                              insertRepository,
                              deleteRepository,
                              replaceRepository);
}
