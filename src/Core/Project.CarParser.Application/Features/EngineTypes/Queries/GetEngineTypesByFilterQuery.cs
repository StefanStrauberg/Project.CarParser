namespace Project.CarParser.Application.Features.EngineTypes.Queries;

public record GetEngineTypesByFilterQuery(RequestParameters Parameters) : FindEntitiesByFilterQuery<ShortEngineTypeDTO>(Parameters);

internal class GetEngineTypesByFilterQueryHandler(IEngineTypeUnitOfWork engineTypeUnitOfWork,
                                                  IEngineTypeSpecification specification,
                                                  IQueryFilterParser queryFilterParser,
                                                  IMapper mapper)
  : FindEntitiesByFilterQueryHandler<EngineType, ShortEngineTypeDTO, GetEngineTypesByFilterQuery>(specification,
                                                                                                  queryFilterParser,
                                                                                                  mapper)
{
  protected override async Task<int> CountResultsAsync(ISpecification<EngineType> specification,
                                                       CancellationToken cancellationToken)
    => await engineTypeUnitOfWork.EngineTypies.GetCountAsync(specification, cancellationToken);

  protected override async Task<IEnumerable<EngineType>> FetchEntitiesAsync(ISpecification<EngineType> specification,
                                                                            CancellationToken cancellationToken)
    => await engineTypeUnitOfWork.EngineTypies.GetManyShortAsync(specification, cancellationToken);
}
