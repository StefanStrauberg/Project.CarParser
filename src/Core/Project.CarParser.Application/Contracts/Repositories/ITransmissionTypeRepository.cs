namespace Project.CarParser.Application.Contracts.Repositories;

public interface ITransmissionTypeRepository
  : IManyQueryRepository<TransmissionType>,
    IOneQueryRepository<TransmissionType>,
    IExistenceQueryRepository<TransmissionType>,
    ICountRepository<TransmissionType>,
    IInsertRepository<TransmissionType>,
    IDeleteRepository<TransmissionType>,
    IReplaceRepository<TransmissionType>
{ }