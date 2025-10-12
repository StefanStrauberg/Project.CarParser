namespace Project.CarParser.Application.Features.PlaceCities.Queries;

public record GetPlaceCityByIdQuery(Guid Id) : FindEntityByIdQuery<DetailPlaceCityDTO>(Id);

internal class GetPlaceCityByIdQueryHandler(IPlaceCityUnitOfWork placeCityUnitOfWork,
                                            IPlaceCitySpecification specification,
                                            IQueryFilterParser queryFilterParser,
                                            IMapper mapper)
  : FindEntityByIdQueryHandler<PlaceCity, DetailPlaceCityDTO, GetPlaceCityByIdQuery>(specification,
                                                                                     queryFilterParser,
                                                                                     mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;

  protected override ISpecification<PlaceCity> BuildSpecification(Guid Id)
  {
    var reqParams = RequestParametersFactory.ForId(Id);
    var filterExpr = _queryFilterParser.ParseFilters<PlaceCity>(reqParams.Filters);
    var spec = specification.Clone();

    if (filterExpr is not null)
      spec.AddFilter(filterExpr);

    return spec;
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<PlaceCity> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await placeCityUnitOfWork.PlaceCities.AnyByQueryAsync(specification, cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(PlaceCity), specification.ToString() ?? string.Empty);
  }

  protected override async Task<PlaceCity> FetchEntityAsync(ISpecification<PlaceCity> specification,
                                                            CancellationToken cancellationToken)
    => await placeCityUnitOfWork.PlaceCities.GetOneShortAsync(specification, cancellationToken);
}

