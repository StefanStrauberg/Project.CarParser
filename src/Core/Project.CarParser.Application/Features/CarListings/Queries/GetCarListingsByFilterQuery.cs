namespace Project.CarParser.Application.Features.CarListings.Queries;

public record GetCarListingsByFilterQuery(RequestParameters Parameters) : FindEntitiesByFilterQuery<ShortCarListingDTO>(Parameters);

internal class GetCarListingsByFilterQueryHandler(ICarListingUnitOfWork carListingUnitOfWork,
                                                  ICarListingSpecification specification,
                                                  IQueryFilterParser queryFilterParser,
                                                  IMapper mapper)
  : FindEntitiesByFilterQueryHandler<CarListing, ShortCarListingDTO, GetCarListingsByFilterQuery>(specification,
                                                                                                  queryFilterParser,
                                                                                                  mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;

  protected override ISpecification<CarListing> BuildSpecification(RequestParameters requestParameters)
  {
    var filterExpr = _queryFilterParser.ParseFilters<CarListing>(requestParameters.Filters);
    var spec = specification.AddInclude(x => x.PlaceRegion)
                            .AddInclude(x => x.PlaceCity)
                            .AddInclude(x => x.TransmissionType)
                            .AddInclude(x => x.EngineType)
                            .AddInclude(x => x.BodyType)
                            .Clone();

    if (filterExpr is not null)
      spec.AddFilter(filterExpr);

    return spec;
  }

  protected override async Task<int> CountResultsAsync(ISpecification<CarListing> specification,
                                                       CancellationToken cancellationToken)
    => await carListingUnitOfWork.CarListings.GetCountAsync(specification, cancellationToken);

  protected override async Task<IEnumerable<CarListing>> FetchEntitiesAsync(ISpecification<CarListing> specification,
                                                                            CancellationToken cancellationToken)
    => await carListingUnitOfWork.CarListings.GetManyShortAsync(specification, cancellationToken);
}
