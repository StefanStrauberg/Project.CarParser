namespace Project.CarParser.Application.Contracts.Repositories;

public interface IEngineTypeRepository
  : IRepository<EngineType>,
    IManyQueryRepository<EngineType>,
    ICountRepository<EngineType>,
    IInsertRepository<EngineType>,
    IDeleteRepository<EngineType>,
    IReplaceRepository<EngineType>
{ }