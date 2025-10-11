namespace Project.CarParser.Application.Features.BodyTypes.Queries;

public record GetBodyTypesByFilterQuery(RequestParameters Parameters) : FindEntitiesByFilterQuery<ShortBodyTypeDTO>(Parameters);

internal class GetBodyTypesByFilterQueryHandler(IBodyTypeUnitOfWork bodyTypeUnitOfWork,
                                                IBodyTypeSpecification specification,
                                                IQueryFilterParser queryFilterParser,
                                                IMapper mapper)
  : FindEntitiesByFilterQueryHandler<BodyType, ShortBodyTypeDTO, GetBodyTypesByFilterQuery>(specification,
                                                                                            queryFilterParser,
                                                                                            mapper)
{
  protected override async Task<int> CountResultsAsync(ISpecification<BodyType> specification,
                                                       CancellationToken cancellationToken)
    => await bodyTypeUnitOfWork.BodyTypies.GetCountAsync(specification, cancellationToken);

  protected override async Task<IEnumerable<BodyType>> FetchEntitiesAsync(ISpecification<BodyType> specification,
                                                                          CancellationToken cancellationToken)
    => await bodyTypeUnitOfWork.BodyTypies.GetManyShortAsync(specification, cancellationToken);
}