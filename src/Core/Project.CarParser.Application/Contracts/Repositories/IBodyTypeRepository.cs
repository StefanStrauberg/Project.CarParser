namespace Project.CarParser.Application.Contracts.Repositories;

public interface IBodyTypeRepository
  : IRepository<BodyType>,
    ICountRepository<BodyType>,
    IInsertRepository<BodyType>,
    IDeleteRepository<BodyType>,
    IReplaceRepository<BodyType>
{ }