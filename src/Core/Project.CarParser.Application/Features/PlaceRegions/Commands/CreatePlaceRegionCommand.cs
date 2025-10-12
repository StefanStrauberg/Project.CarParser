namespace Project.CarParser.Application.Features.PlaceRegions.Commands;

public record CreatePlaceRegionCommand(CreatePlaceRegionDTO PlaceRegionDTO)
  : CreateEntityCommand<CreatePlaceRegionDTO>(PlaceRegionDTO);

internal class CreatePlaceRegionCommandHandler(IPlaceRegionUnitOfWork placeRegionUnitOfWork,
                                               IPlaceRegionSpecification specification,
                                               IQueryFilterParser queryFilterParser,
                                               IMapper mapper)
  : CreateEntityCommandHandler<PlaceRegion, CreatePlaceRegionDTO, CreatePlaceRegionCommand>(specification,
                                                                                            mapper)
{
  protected override Expression<Func<PlaceRegion, bool>>? BuildDuplicateCheckFilter(CreatePlaceRegionDTO createDto)
    => queryFilterParser.ParseFilters<PlaceRegion>(new RequestParameters
    {
      Filters =
        [
          new()
          {
            PropertyPath = nameof(PlaceRegion.Name),
            Operator = FilterOperator.Equals,
            Value = createDto.Name
          }
        ]
    }.Filters);

  protected override void PersistNewEntity(PlaceRegion entity)
  {
    placeRegionUnitOfWork.StartTransaction();
    placeRegionUnitOfWork.PlaceRegions.InsertOne(entity);
    placeRegionUnitOfWork.Complete();
  }

  protected override async Task ValidateEntityDoesNotExistAsync(ISpecification<PlaceRegion> specification,
                                                                CancellationToken cancellationToken)
  {
    bool exists = await placeRegionUnitOfWork.PlaceRegions.AnyByQueryAsync(specification,
                                                                           cancellationToken);

    if (exists is true)
      throw new EntityAlreadyExists(typeof(PlaceRegion), specification.ToString() ?? string.Empty);
  }
}
