namespace Project.CarParser.Application.Features.CarListings.Queries;

public record GetCarListingByIdQuery(Guid Id) : FindEntityByIdQuery<DetailCarListingDTO>(Id);

internal class GetCarListingByIdQueryHandler(ICarListingUnitOfWork carListingUnitOfWork,
                                             ICarListingSpecification specification,
                                             IQueryFilterParser queryFilterParser,
                                             IMapper mapper)
  : FindEntityByIdQueryHandler<CarListing, DetailCarListingDTO, GetCarListingByIdQuery>(specification,
                                                                                        queryFilterParser,
                                                                                        mapper)
{
  readonly IQueryFilterParser _queryFilterParser = queryFilterParser;

  protected override ISpecification<CarListing> BuildSpecification(Guid Id)
  {
    var reqParams = RequestParametersFactory.ForId(Id);
    var filterExpr = _queryFilterParser.ParseFilters<CarListing>(reqParams.Filters);
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

  protected override async Task EnsureEntityExistAsync(ISpecification<CarListing> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await carListingUnitOfWork.CarListings.AnyByQueryAsync(specification, cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(CarListing), specification.ToString() ?? string.Empty);
  }

  protected override async Task<CarListing> FetchEntityAsync(ISpecification<CarListing> specification,
                                                             CancellationToken cancellationToken)
    => await carListingUnitOfWork.CarListings.GetOneShortAsync(specification, cancellationToken);
}
