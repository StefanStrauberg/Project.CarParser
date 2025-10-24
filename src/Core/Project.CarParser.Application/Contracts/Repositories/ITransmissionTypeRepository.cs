namespace Project.CarParser.Application.Contracts.Repositories;

public interface ITransmissionTypeRepository
  : IRepository<TransmissionType>,
    ICountRepository<TransmissionType>,
    IInsertRepository<TransmissionType>,
    IDeleteRepository<TransmissionType>,
    IReplaceRepository<TransmissionType>
{ }