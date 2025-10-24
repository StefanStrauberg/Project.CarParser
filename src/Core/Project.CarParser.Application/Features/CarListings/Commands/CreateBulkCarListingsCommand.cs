namespace Project.CarParser.Application.Features.CarListings.Commands;

public record CreateBulkCarListingsCommand(IEnumerable<CreateCarListingDTO> CreateDtos)
  : CreateBulkEntitiesCommand<CreateCarListingDTO>(CreateDtos);

internal class CreateBulkCarListingsCommandHandler(ICarListingUnitOfWork carListingUnitOfWork,
                                                   ICarListingSpecification carListingSpecification,
                                                   IMapper mapper)
  : CreateBulkEntitiesCommandHandler<CarListing, CreateCarListingDTO, CreateBulkCarListingsCommand>(carListingSpecification, mapper)
{
  protected override Expression<Func<CarListing, bool>>? BuildDuplicateCheckFilter(IEnumerable<CreateCarListingDTO> dtos)
  {
    var ids = dtos.Select(dto => dto.Url).Where(id => id != null).ToList();

    if (!ids.Any())
      return null;

    return entity => ids.Contains(entity.ExternalId);
  }

  protected override void PersistNewEntities(IEnumerable<CarListing> entities)
  {
    throw new NotImplementedException();
  }

  protected override async Task ValidateEntitiesDoNotExistAsync(ISpecification<CarListing> specification,
                                                                CancellationToken cancellationToken)
  {
    bool exists = await carListingUnitOfWork.CarListings.AnyByQueryAsync(specification,
                                                                         cancellationToken);

    if (exists is not true)
      throw new EntityNotFoundException(typeof(CarListing), specification.ToString() ?? string.Empty);
  }
}