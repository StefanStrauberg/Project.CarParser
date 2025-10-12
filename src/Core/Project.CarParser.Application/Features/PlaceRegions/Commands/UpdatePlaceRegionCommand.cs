namespace Project.CarParser.Application.Features.PlaceRegions.Commands;

public record UpdatePlaceRegionCommand(UpdatePlaceRegionDTO UpdatePlaceRegionDTO)
  : UpdateEntityCommand<PlaceRegion, UpdatePlaceRegionDTO>(UpdatePlaceRegionDTO.Id, UpdatePlaceRegionDTO);

internal class UpdatePlaceRegionCommandHandler(IPlaceRegionUnitOfWork placeRegionUnitOfWork,
                                               IPlaceRegionSpecification specification,
                                               IQueryFilterParser queryFilterParser,
                                               IMapper mapper)
  : UpdateEntityCommandHandler<PlaceRegion, UpdatePlaceRegionDTO, UpdatePlaceRegionCommand>(specification,
                                                                                            queryFilterParser,
                                                                                            mapper)
{
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

  protected override void UpdateEntity(PlaceRegion entity)
  {
    placeRegionUnitOfWork.PlaceRegions.ReplaceOne(entity);
    placeRegionUnitOfWork.Complete();
  }
}
