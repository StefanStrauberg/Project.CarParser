namespace Project.CarParser.Application.Features.PlaceCities.Queries;

public record GetPlaceCitiesByFilterQuery(RequestParameters Parameters) : FindEntitiesByFilterQuery<ShortPlaceCityDTO>(Parameters);

internal class GetPlaceCitiesByFilterQueryHandler(IPlaceCityUnitOfWork placeCityUnitOfWork,
                                                  IPlaceCitySpecification specification,
                                                  IQueryFilterParser queryFilterParser,
                                                  IMapper mapper)
  : FindEntitiesByFilterQueryHandler<PlaceCity, ShortPlaceCityDTO, GetPlaceCitiesByFilterQuery>(specification,
                                                                                                queryFilterParser,
                                                                                                mapper)
{
  protected override async Task<int> CountResultsAsync(ISpecification<PlaceCity> specification,
                                                       CancellationToken cancellationToken)
    => await placeCityUnitOfWork.PlaceCities.GetCountAsync(specification, cancellationToken);

  protected override async Task<IEnumerable<PlaceCity>> FetchEntitiesAsync(ISpecification<PlaceCity> specification,
                                                                           CancellationToken cancellationToken)
    => await placeCityUnitOfWork.PlaceCities.GetManyShortAsync(specification, cancellationToken);
}
