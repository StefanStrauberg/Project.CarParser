namespace Project.CarParser.Application.Features.PlaceRegions.Commands;

public record DeletePlaceRegionCommand(Guid Id) : DeleteEntityCommand(Id);

internal class DeletePlaceRegionCommandHandler(IPlaceRegionUnitOfWork placeRegionUnitOfWork,
                                               IPlaceRegionSpecification specification,
                                               IQueryFilterParser queryFilterParser)
: DeleteEntityCommandHandler<PlaceRegion, DeletePlaceRegionCommand>(specification,
                                                                    queryFilterParser)
{
  protected override void DeleteEntity(PlaceRegion entity)
  {
    placeRegionUnitOfWork.PlaceRegions.DeleteOne(entity);
    placeRegionUnitOfWork.Complete();
  }

  protected override async Task EnsureEntityExistAsync(ISpecification<PlaceRegion> specification,
                                                       CancellationToken cancellationToken)
  {
    bool exists = await placeRegionUnitOfWork.PlaceRegions.AnyByQueryAsync(specification,
                                                                           cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(PlaceRegion), specification.ToString() ?? string.Empty);
  }

  protected override async Task<PlaceRegion> FetchEntityAsync(ISpecification<PlaceRegion> specification,
                                                              CancellationToken cancellationToken)
    => await placeRegionUnitOfWork.PlaceRegions.GetOneShortAsync(specification, cancellationToken);
}
