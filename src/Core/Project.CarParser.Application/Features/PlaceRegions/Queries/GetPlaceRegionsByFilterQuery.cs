namespace Project.CarParser.Application.Features.PlaceRegions.Queries;

public record GetPlaceRegionsByFilterQuery(RequestParameters Parameters) : FindEntitiesByFilterQuery<ShortPlaceRegionDTO>(Parameters);

internal class GetPlaceRegionsByFilterQueryHandler(IPlaceRegionUnitOfWork placeRegionUnitOfWork,
                                                   IPlaceRegionSpecification specification,
                                                   IQueryFilterParser queryFilterParser,
                                                   IMapper mapper)
  : FindEntitiesByFilterQueryHandler<PlaceRegion, ShortPlaceRegionDTO, GetPlaceRegionsByFilterQuery>(specification,
                                                                                                     queryFilterParser,
                                                                                                     mapper)
{
  protected override async Task<int> CountResultsAsync(ISpecification<PlaceRegion> specification,
                                                       CancellationToken cancellationToken)
    => await placeRegionUnitOfWork.PlaceRegions.GetCountAsync(specification, cancellationToken);

  protected override async Task<IEnumerable<PlaceRegion>> FetchEntitiesAsync(ISpecification<PlaceRegion> specification,
                                                                             CancellationToken cancellationToken)
    => await placeRegionUnitOfWork.PlaceRegions.GetManyShortAsync(specification, cancellationToken);
}
