namespace Project.CarParser.Application.Features.EngineTypes.Queries;

public record GetEngineTypeByIdQuery(Guid Id) : FindEntityByIdQuery<DetailEngineTypeDTO>(Id);

internal class GetEngineTypeByIdQueryHandler(IEngineTypeUnitOfWork engineTypeUnitOfWork,
                                             IEngineTypeSpecification specification,
                                             IQueryFilterParser queryFilterParser,
                                             IMapper mapper)
  : FindEntityByIdQueryHandler<EngineType, DetailEngineTypeDTO, GetEngineTypeByIdQuery>(specification,
                                                                                  queryFilterParser,
                                                                                  mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;

  protected override ISpecification<EngineType> BuildSpecification(Guid Id)
  {
    var reqParams = RequestParametersFactory.ForId(Id);
    var filterExpr = _queryFilterParser.ParseFilters<EngineType>(reqParams.Filters);
    var spec = specification.Clone();

    if (filterExpr is not null)
      spec.AddFilter(filterExpr);

    return spec;
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<EngineType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await engineTypeUnitOfWork.EngineTypes.AnyByQueryAsync(specification, cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(EngineType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<EngineType> FetchEntityAsync(ISpecification<EngineType> specification,
                                                             CancellationToken cancellationToken)
    => await engineTypeUnitOfWork.EngineTypes.GetOneShortAsync(specification, cancellationToken);
}
