namespace Project.CarParser.Application.Features.PlaceRegions.Queries;

public record GetPlaceRegionByIdQuery(Guid Id) : FindEntityByIdQuery<DetailPlaceRegionDTO>(Id);

internal class GetPlaceRegionByIdQueryHandler(IPlaceRegionUnitOfWork placeRegionUnitOfWork,
                                              IPlaceRegionSpecification specification,
                                              IQueryFilterParser queryFilterParser,
                                              IMapper mapper)
  : FindEntityByIdQueryHandler<PlaceRegion, DetailPlaceRegionDTO, GetPlaceRegionByIdQuery>(specification,
                                                                                           queryFilterParser,
                                                                                           mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;

  protected override ISpecification<PlaceRegion> BuildSpecification(Guid Id)
  {
    var reqParams = RequestParametersFactory.ForId(Id);
    var filterExpr = _queryFilterParser.ParseFilters<PlaceRegion>(reqParams.Filters);
    var spec = specification.Clone();

    if (filterExpr is not null)
      spec.AddFilter(filterExpr);

    return spec;
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<PlaceRegion> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await placeRegionUnitOfWork.PlaceRegions.AnyByQueryAsync(specification, cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(PlaceRegion), specification.ToString() ?? string.Empty);
  }

  protected override async Task<PlaceRegion> FetchEntityAsync(ISpecification<PlaceRegion> specification,
                                                              CancellationToken cancellationToken)
    => await placeRegionUnitOfWork.PlaceRegions.GetOneShortAsync(specification, cancellationToken);
}
