namespace Project.CarParser.Application.Features.TransmissionTypes.Queries;

public record GetTransmissionTypesByFilterQuery(RequestParameters Parameters) : FindEntitiesByFilterQuery<ShortTransmissionTypeDTO>(Parameters);

internal class GetTransmissionTypesByFilterQueryHandler(ITransmissionTypeUnitOfWork transmissionTypeUnitOfWork,
                                                        ITransmissionTypeSpecification specification,
                                                        IQueryFilterParser queryFilterParser,
                                                        IMapper mapper)
  : FindEntitiesByFilterQueryHandler<TransmissionType, ShortTransmissionTypeDTO, GetTransmissionTypesByFilterQuery>(specification,
                                                                                                                    queryFilterParser,
                                                                                                                    mapper)
{
  protected override async Task<int> CountResultsAsync(ISpecification<TransmissionType> specification,
                                                       CancellationToken cancellationToken)
    => await transmissionTypeUnitOfWork.TransmissionTypies.GetCountAsync(specification, cancellationToken);

  protected override async Task<IEnumerable<TransmissionType>> FetchEntitiesAsync(ISpecification<TransmissionType> specification,
                                                                                  CancellationToken cancellationToken)
    => await transmissionTypeUnitOfWork.TransmissionTypies.GetManyShortAsync(specification, cancellationToken);
}
