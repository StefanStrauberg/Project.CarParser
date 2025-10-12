namespace Project.CarParser.Application.Features.PlaceCities.Commands;

public record DeletePlaceCityCommand(Guid Id) : DeleteEntityCommand(Id);

internal class DeletePlaceCityCommandHandler(IPlaceCityUnitOfWork placeCityUnitOfWork,
                                              IPlaceCitySpecification specification,
                                              IQueryFilterParser queryFilterParser)
: DeleteEntityCommandHandler<PlaceCity, DeletePlaceCityCommand>(specification,
                                                                  queryFilterParser)
{
  protected override void DeleteEntity(PlaceCity entity)
  {
    placeCityUnitOfWork.PlaceCities.DeleteOne(entity);
    placeCityUnitOfWork.Complete();
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<PlaceCity> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await placeCityUnitOfWork.PlaceCities.AnyByQueryAsync(specification,
                                                                          cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(PlaceCity), specification.ToString() ?? string.Empty);
  }

  protected override async Task<PlaceCity> FetchEntityAsync(ISpecification<PlaceCity> specification,
                                                             CancellationToken cancellationToken)
    => await placeCityUnitOfWork.PlaceCities.GetOneShortAsync(specification, cancellationToken);
}
