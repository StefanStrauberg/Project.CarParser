namespace Project.CarParser.Application.Features.BodyTypes.Queries;

public record GetBodyTypeByIdQuery(Guid Id) : FindEntityByIdQuery<DetailBodyTypeDTO>(Id);

internal class GetBodyTypeByIdQueryHandler(IBodyTypeUnitOfWork bodyTypeUnitOfWork,
                                           IBodyTypeSpecification specification,
                                           IQueryFilterParser queryFilterParser,
                                           IMapper mapper)
  : FindEntityByIdQueryHandler<BodyType, DetailBodyTypeDTO, GetBodyTypeByIdQuery>(specification,
                                                                                  queryFilterParser,
                                                                                  mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;

  protected override ISpecification<BodyType> BuildSpecification(Guid Id)
  {
    var reqParams = RequestParametersFactory.ForId(Id);
    var filterExpr = _queryFilterParser.ParseFilters<BodyType>(reqParams.Filters);
    var spec = specification.Clone();

    if (filterExpr is not null)
      spec.AddFilter(filterExpr);

    return spec;
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<BodyType> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await bodyTypeUnitOfWork.BodyTypes.AnyByQueryAsync(specification, cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(BodyType), specification.ToString() ?? string.Empty);
  }

  protected override async Task<BodyType> FetchEntityAsync(ISpecification<BodyType> specification,
                                                           CancellationToken cancellationToken)
    => await bodyTypeUnitOfWork.BodyTypes.GetOneShortAsync(specification, cancellationToken);
}
