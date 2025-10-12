namespace Project.CarParser.Application.Features.PlaceCities.Commands;

public record CreatePlaceCityCommand(CreatePlaceCityDTO PlaceCityDTO)
  : CreateEntityCommand<CreatePlaceCityDTO>(PlaceCityDTO);

internal class CreatePlaceCityCommandHandler(IPlaceCityUnitOfWork placeCityUnitOfWork,
                                             IPlaceCitySpecification specification,
                                             IQueryFilterParser queryFilterParser,
                                             IMapper mapper)
  : CreateEntityCommandHandler<PlaceCity, CreatePlaceCityDTO, CreatePlaceCityCommand>(specification,
                                                                                   mapper)
{
  protected override Expression<Func<PlaceCity, bool>>? BuildDuplicateCheckFilter(CreatePlaceCityDTO createDto)
    => queryFilterParser.ParseFilters<PlaceCity>(new RequestParameters
    {
      Filters =
        [
          new()
          {
            PropertyPath = nameof(PlaceCity.Name),
            Operator = FilterOperator.Equals,
            Value = createDto.Name
          }
        ]
    }.Filters);

  protected override void PersistNewEntity(PlaceCity entity)
  {
    placeCityUnitOfWork.StartTransaction();
    placeCityUnitOfWork.PlaceCities.InsertOne(entity);
    placeCityUnitOfWork.Complete();
  }

  protected override async Task ValidateEntityDoesNotExistAsync(ISpecification<PlaceCity> specification,
                                                                CancellationToken cancellationToken)
  {
    bool exists = await placeCityUnitOfWork.PlaceCities.AnyByQueryAsync(specification,
                                                                        cancellationToken);

    if (exists is true)
      throw new EntityAlreadyExists(typeof(PlaceCity), specification.ToString() ?? string.Empty);
  }
}
