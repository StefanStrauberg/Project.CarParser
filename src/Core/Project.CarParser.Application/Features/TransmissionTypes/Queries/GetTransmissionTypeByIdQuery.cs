namespace Project.CarParser.Application.Features.TransmissionTypes.Queries;

public record GetTransmissionTypeByIdQuery(Guid Id) : FindEntityByIdQuery<DetailTransmissionTypeDTO>(Id);

internal class GetTransmissionTypeByIdQueryHandler(ITransmissionTypeUnitOfWork transmissionTypeUnitOfWork,
                                                   ITransmissionTypeSpecification specification,
                                                   IQueryFilterParser queryFilterParser,
                                                   IMapper mapper)
  : FindEntityByIdQueryHandler<TransmissionType, DetailTransmissionTypeDTO, GetTransmissionTypeByIdQuery>(specification,
                                                                                                          queryFilterParser,
                                                                                                          mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;

  protected override ISpecification<TransmissionType> BuildSpecification(Guid Id)
  {
    var reqParams = RequestParametersFactory.ForId(Id);
    var filterExpr = _queryFilterParser.ParseFilters<TransmissionType>(reqParams.Filters);
    var spec = specification.Clone();

    if (filterExpr is not null)
      spec.AddFilter(filterExpr);

    return spec;
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<TransmissionType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await transmissionTypeUnitOfWork.TransmissionTypies.AnyByQueryAsync(specification, cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(TransmissionType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<TransmissionType> FetchEntityAsync(ISpecification<TransmissionType> specification,
                                                                   CancellationToken cancellationToken)
    => await transmissionTypeUnitOfWork.TransmissionTypies.GetOneShortAsync(specification, cancellationToken);
}
