namespace Project.CarParser.Application.Contracts.Repositories;

public interface IBodyTypeRepository
  : IManyQueryRepository<BodyType>,
    IOneQueryRepository<BodyType>,
    IExistenceQueryRepository<BodyType>,
    ICountRepository<BodyType>,
    IInsertRepository<BodyType>,
    IDeleteRepository<BodyType>,
    IReplaceRepository<BodyType>
{ }