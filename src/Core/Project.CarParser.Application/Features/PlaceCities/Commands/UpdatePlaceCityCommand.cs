namespace Project.CarParser.Application.Features.PlaceCities.Commands;

public record UpdatePlaceCityCommand(UpdatePlaceCityDTO UpdatePlaceCityDTO)
  : UpdateEntityCommand<PlaceCity, UpdatePlaceCityDTO>(UpdatePlaceCityDTO.Id, UpdatePlaceCityDTO);

internal class UpdatePlaceCityCommandHandler(IPlaceCityUnitOfWork placeCityUnitOfWork,
                                             IPlaceCitySpecification specification,
                                             IQueryFilterParser queryFilterParser,
                                             IMapper mapper)
  : UpdateEntityCommandHandler<PlaceCity, UpdatePlaceCityDTO, UpdatePlaceCityCommand>(specification,
                                                                                      queryFilterParser,
                                                                                      mapper)
{
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

  protected override void UpdateEntity(PlaceCity entity)
  {
    placeCityUnitOfWork.PlaceCities.ReplaceOne(entity);
    placeCityUnitOfWork.Complete();
  }
}
